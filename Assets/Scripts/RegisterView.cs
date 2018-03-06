using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterView : MonoBehaviour {

    public GameObject registerPanel;
    public List<GameObject> adresReferencesList;
    public List<GameObject> personalReferencesList;
    public GameObject registerWindow;
    public InputField email;
    public InputField password;
    public InputField rePassword;
    public InputField userName;
    public InputField lastName;
    public InputField city;
    public InputField cityCode;
    public InputField streetName;
    public InputField streetNumber;
    public Button registerButton;
    void Start () {
        //Setting refs for Register Panel
        SetRegisterReferences();

        userName = personalReferencesList[1].transform.GetChild(0).GetComponent<InputField>();
        lastName = personalReferencesList[2].transform.GetChild(0).GetComponent<InputField>();
        email = personalReferencesList[3].transform.GetChild(0).GetComponent<InputField>();
        password = personalReferencesList[4].transform.GetChild(0).GetComponent<InputField>();
        rePassword = personalReferencesList[5].transform.GetChild(0).GetComponent<InputField>();

        city = adresReferencesList[1].transform.GetChild(0).GetComponent<InputField>();
        cityCode = adresReferencesList[2].transform.GetChild(0).GetComponent<InputField>();
        streetName = adresReferencesList[3].transform.GetChild(0).GetComponent<InputField>();
        streetNumber = adresReferencesList[4].transform.GetChild(0).GetComponent<InputField>();
        


    }
    //register panel is split in two part, setting refs for to list personal and adres
    private void SetRegisterReferences()
    {
        registerPanel = this.gameObject;
        for (int i = 0; i < registerPanel.transform.GetChild(1).childCount; i++)
        {
            adresReferencesList.Add(registerPanel.transform.GetChild(1).GetChild(i).gameObject);
        }
        for (int i = 0; i < registerPanel.transform.GetChild(0).childCount; i++)
        {
            personalReferencesList.Add(registerPanel.transform.GetChild(0).GetChild(i).gameObject);
        }
    }


}
