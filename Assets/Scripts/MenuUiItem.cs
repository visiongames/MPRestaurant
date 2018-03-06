using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUiItem : MonoBehaviour {

    public ProductElementModel currentProduct;
    public Image productIcon;
    public Text productName;
    public Text productPrice;
    public Text productType;
    public GameObject additionGrid;
    public Button addButton;
    public Button removeButton;
    public Text quantityText;

    public int currentQuantity;

	void Start () {
        quantityText.text = currentQuantity.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetProductData(ProductElementModel _product)
    {
        currentProduct = _product;
        SetUi();
    }
    public void SetUi()
    {
        productName.text = currentProduct.productName;
        productPrice.text = currentProduct.productPrice.ToString();
        productType.text = currentProduct.productType;
        SetAdditionsUi();
    }

    public void SetAdditionsUi()
    {
        for (int i = 0; i < currentProduct.listOfProductAddition.Count; i++)
        {
            GameObject singleProduct = Instantiate(Resources.Load<GameObject>("Addition"));
            singleProduct.transform.SetParent(additionGrid.transform, false);
            singleProduct.transform.GetChild(0).GetComponent<Text>().text = currentProduct.listOfProductAddition[i].AdditionName;
            singleProduct.transform.GetChild(1).GetComponent<Text>().text = currentProduct.listOfProductAddition[i].AdditionPrice.ToString();
            singleProduct.GetComponent<AdditionUi>().additionID = i;
            singleProduct.GetComponent<AdditionUi>().additionParentRef = this.gameObject;
        }
    }

    public void AddQuantity()
    {
        currentQuantity++;
        quantityText.text = currentQuantity.ToString();
        currentProduct.productQuantity = currentQuantity;
        ChangePrice();
    }

    public void RemoveQuantity()
    {
        if(currentQuantity > 0)
        {
            currentQuantity--;
            quantityText.text = currentQuantity.ToString();
            currentProduct.productQuantity = currentQuantity;
            ChangePrice();
        }
    }

    public void SetAddition(int _additionId)
    {
        currentProduct.listOfProductAddition[_additionId].IsSelected = !currentProduct.listOfProductAddition[_additionId].IsSelected;
        ChangePrice();
    }

    public void ChangePrice()
    {    
        ClientController.Instance.InitOrder(currentProduct); 
    }

}
