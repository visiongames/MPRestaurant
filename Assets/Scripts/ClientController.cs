using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ClientController : MonoBehaviour {

    public static ClientController Instance;

    public ProductModel productMenuData;
    public OrderElementModel currentOrder;
    public ClientElementModel currentClientData;
    private EmailSender orderEmailSender;
    public float currentOrderPrice;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        orderEmailSender = new EmailSender();
        LoadRestaurantMenu();
        CreateRestaurantMenu();
        currentOrder = new OrderElementModel();
        //OnPriceChange += CallEvent;
    }

    public void CreateRestaurantMenu()
    {
        for (int i = 0; i < productMenuData.listOfAllProducts.Count; i++)
        {
            GameObject singleProduct = Instantiate(Resources.Load<GameObject>("MenuUiItem"));
            singleProduct.transform.SetParent(ClientView.Instance.productGrid.transform, false);
            singleProduct.GetComponent<MenuUiItem>().SetProductData(productMenuData.listOfAllProducts[i]);
        }
    }
    public void InitClient(ClientElementModel _currentClientData)
    {
        ClientView.Instance.InitClientUI();
        currentClientData = _currentClientData;
        InitUserEditData();
    }

    public void InitOrder(ProductElementModel currentProduct)
    {

        Debug.Log(currentProduct.productName);

        if (CheckForProductInOrder(currentProduct) == null)
        {
            currentOrder.listOfProductInOrder.Add(currentProduct);
        }
        CalculatePrice();
       
    }

    public ProductElementModel CheckForProductInOrder(ProductElementModel _currentProduct)
    {
        foreach (var product in currentOrder.listOfProductInOrder)
        {
            if (product.productName == _currentProduct.productName)
            {
                return product;
            }

        }
        return null;
    }

    public void CalculatePrice()
    {
        currentOrderPrice = 0;
        for (int i = 0; i < currentOrder.listOfProductInOrder.Count; i++)
        {

            currentOrderPrice += currentOrder.listOfProductInOrder[i].productPrice * currentOrder.listOfProductInOrder[i].productQuantity;
            for (int j = 0; j < currentOrder.listOfProductInOrder[i].listOfProductAddition.Count; j++)
            {
                if(currentOrder.listOfProductInOrder[i].listOfProductAddition[j].IsSelected == true)
                {
                    currentOrderPrice += currentOrder.listOfProductInOrder[i].listOfProductAddition[j].AdditionPrice;
                }
            }
            

        }
        if (currentOrderPrice < 100)
        {
            //Adding Delivery fee
            currentOrderPrice += 25;
            ClientView.Instance.deliverCost.text = 25.ToString();
        }
        else { ClientView.Instance.deliverCost.text = 0.ToString(); }
        currentOrder.orderSummary = currentOrderPrice;
        ClientView.Instance.priceText.text = currentOrderPrice.ToString();
    }
    public void CreateOrder()
    {
        ClientView.Instance.additionalPanel.SetActive(true);
    }
    public void FinishOrder()
    {
        currentClientData.userOrders.Add(currentOrder);
        SaveUserOrder();
        OpenUserOrders();
        
        orderEmailSender.SendEmails(currentClientData.email, currentOrder.orderId.ToString(), currentOrder.orderSummary.ToString());
    }
    
    public void LoadRestaurantMenu()
    {
        string folder = Application.dataPath + "/StreamingAssets";
        string fileName = "ProductData.json";
        string fullPath = Path.Combine(folder, fileName);
        string jasonString = File.ReadAllText(fullPath);
        productMenuData = JsonUtility.FromJson<ProductModel>(jasonString);
    }
    public void SaveUserOrder()
    {
        string folder = Application.dataPath + "/StreamingAssets";
        string fileName = "ClientsData.json";
        string fullPath = Path.Combine(folder, fileName);
        string jasonString = File.ReadAllText(fullPath);
        ClientModel tempUsers = JsonUtility.FromJson<ClientModel>(jasonString);
        
        foreach (var user in tempUsers.userList)
        {
            if (user.id == currentClientData.id)
            {
                currentOrder.orderId = currentClientData.userOrders.Count;
                user.userOrders.Add(currentOrder);
            }
        }
        string json = JsonUtility.ToJson(tempUsers);
        File.WriteAllText(fullPath, json);


    }


    public void SetAdditionalOrderDescription()
    {
        if(currentOrder.orderDescription == "")
        {
            currentOrder.orderDescription = "no additional description";
        }
        else
        currentOrder.orderDescription = ClientView.Instance.additionalDescriptionInput.text;
    
    }

    public void PrepareForNextOrder()
    {
        ClientView.Instance.restaurantMenu.SetActive(true);
        ClientView.Instance.userOrdersPanel.SetActive(false);
        ClientView.Instance.additionalPanel.SetActive(false);
        ClientView.Instance.userEditPanelAdress.SetActive(false);
        ClientView.Instance.userEditPanelPersonal.SetActive(false);
        currentOrder = new OrderElementModel();
        LoadRestaurantMenu();
        for (int i = 0; i < ClientView.Instance.productGrid.transform.childCount; i++)
        {
            Destroy(ClientView.Instance.productGrid.transform.GetChild(i).gameObject);
        }
        CreateRestaurantMenu();
        CalculatePrice();
        
        
    }

    public void OpenUserOrders()
    {
        ClientView.Instance.restaurantMenu.SetActive(false);
        ClientView.Instance.userOrdersPanel.SetActive(true);
        ClientView.Instance.userEditPanelAdress.SetActive(false);
        ClientView.Instance.userEditPanelPersonal.SetActive(false);
        CreateOrdersList();

    }
    public void CreateOrdersList()
    {
        Debug.Log(currentClientData.userOrders.Count + "current order count");
        if(ClientView.Instance.userOrdersPanel.transform.childCount > 0)
        {
            for (int i = 0; i < ClientView.Instance.userOrdersPanel.transform.childCount; i++)
            {
                Debug.Log("destroyed");
                Destroy(ClientView.Instance.userOrdersPanel.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < currentClientData.userOrders.Count; i++)
        {
            GameObject userOrder = Instantiate(Resources.Load<GameObject>("Order"));
            userOrder.transform.SetParent(ClientView.Instance.userOrdersPanel.transform, false);
            userOrder.GetComponent<OrderUi>().SetOrderUi(currentClientData.userOrders[i]);
           
        }
    }

    public void InitUserEditData()
    {
        EditUserController.Instance.FillUserEditFields();
    }

    public void OpenUserEdit()
    {
        ClientView.Instance.userEditPanelAdress.SetActive(true);
        ClientView.Instance.userEditPanelPersonal.SetActive(true);
        ClientView.Instance.restaurantMenu.SetActive(false);
        ClientView.Instance.userOrdersPanel.SetActive(false);
        ClientView.Instance.additionalPanel.SetActive(false);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
