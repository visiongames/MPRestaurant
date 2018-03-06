using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoginController : MonoBehaviour {

    public GameObject clientAppUi;
    LoginView loginView;
    
    public string login;
    public string password;

	void Start () {

        loginView = GetComponent<LoginView>();
       
	}
	
    public void SetPassword()
    {
        password = loginView.password.text;
    }
    public void SetLogin()
    {
        login = loginView.userName.text;
    }

    public void CheckUserLogin()
    {
        ClientElementModel userData = GetUserData(login, password);
        if(userData != null)
        {
            Debug.Log("Zalogowano");
            this.transform.parent.gameObject.SetActive(false);
            clientAppUi.SetActive(true);
            
            
            ClientController.Instance.InitClient(userData);
        }
    }
    public ClientElementModel GetUserData(string _userName, string _userPassword)
    {
        string folder = Application.dataPath + "/StreamingAssets";
        string fileName = "ClientsData.json";
        string fullPath = Path.Combine(folder, fileName);
        string jasonString = File.ReadAllText(fullPath);
        ClientModel tempUsers = JsonUtility.FromJson<ClientModel>(jasonString);

        foreach (var user in tempUsers.userList)
        {
            if (user.email == _userName && user.password == _userPassword)
            {
                return user;
            }
        }
        return null;
    }
}
