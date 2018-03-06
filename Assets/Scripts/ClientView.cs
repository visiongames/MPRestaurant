using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientView : MonoBehaviour {

    public static ClientView Instance;

    public GameObject clientMenu;
    public GameObject restaurantMenu;
    public GameObject productGrid;
    public GameObject additionalPanel;
    public GameObject userOrdersPanel;
    public GameObject userEditPanelPersonal;
    public GameObject userEditPanelAdress;
    public InputField additionalDescriptionInput;
    public Text deliverCost;
    public Text priceText;

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
    }

    public void InitClientUI()
    {
        clientMenu.SetActive(true);
        restaurantMenu.SetActive(true);
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
