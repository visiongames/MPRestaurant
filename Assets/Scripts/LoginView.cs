using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginView : MonoBehaviour {

    public InputField userName;
    public InputField password;
    public Button loginButton;
	void Start () {
        userName = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<InputField>();
        password = this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<InputField>();
        loginButton = this.transform.GetChild(0).GetChild(3).GetComponent<Button>();
    }
	
}
