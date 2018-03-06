using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditUserController : MonoBehaviour {

    public static EditUserController Instance;
    public EditUserView editUserView;
    ClientElementModel currentClientData;

    void Start () {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        editUserView = this.GetComponent<EditUserView>();
        
	}
	
	public void FillUserEditFields()
    {
        currentClientData = ClientController.Instance.currentClientData;
        editUserView.city.text = currentClientData.city;
        editUserView.cityCode.text = currentClientData.cityCode;
        editUserView.streetName.text = currentClientData.streetName;
        editUserView.streetNumber.text = currentClientData.streetNumber;
        editUserView.userName.text = currentClientData.userName;
        editUserView.userLastName.text = currentClientData.lastName;
        editUserView.email.text = currentClientData.email;

    }
}
