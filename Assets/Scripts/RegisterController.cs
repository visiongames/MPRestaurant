using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RegisterController : MonoBehaviour {

    public RegisterView registerView;
    public int id;

    private string email;
    private string password;
    private string rePassword;
    private string userName;
    private string lastName;
    private string city;
    private string cityCode;
    private string streetName;
    private string streetNumber;

    private bool isValidemail;
    private bool isValidpassword;
    private bool isValidrePassword;
    private bool isValiduserName;
    private bool isValidlastName;
    private bool isValidcity;
    private bool isValidcityCode;
    private bool isValidstreetName;
    private bool isValidstreetNumber;

	void Start () {

        registerView = this.GetComponent<RegisterView>();
        CheckForFieldsValidation();
	}


    public void ValidateName()
    {
        userName = registerView.userName.text;
        if (userName.Length >= 1)
        {
            SetColorToGreen(registerView.userName);
            isValiduserName = true;
        }
        else
        {
            SetColorToRed(registerView.userName);
            isValiduserName = false;
        }
        CheckForFieldsValidation();
    }

    public void ValidateLastName()
    {
        lastName = registerView.lastName.text;
        if (lastName.Length >= 1)
        {
            SetColorToGreen(registerView.lastName);
            isValidlastName = true;
        }
        else
        {
            SetColorToRed(registerView.lastName);
            isValidlastName = false;
        }
        CheckForFieldsValidation();
    }

    public void ValidateStreetNumber()
    {
        streetNumber = registerView.streetNumber.text;
        if (streetNumber.Length >= 1)
        {
            SetColorToGreen(registerView.streetNumber);
            isValidstreetNumber = true;
        }
        else
        {
            SetColorToRed(registerView.streetNumber);
            isValidstreetNumber = false;
        }
        CheckForFieldsValidation();

    }

    public void ValidateStreetName()
    {
        streetName = registerView.streetName.text;
        if (streetName.Length >= 1)
        {
            SetColorToGreen(registerView.streetName);
            isValidstreetName = true;
        }
        else
        {
            SetColorToRed(registerView.streetName);
            isValidstreetName = false;
        }
        CheckForFieldsValidation();

    }

    public void ValidateEmail()
    {
        email = registerView.email.text;
        if(email.Contains("@") == true)
        {
            SetColorToGreen(registerView.email);
            isValidemail = true;
        }
        else
        {
            SetColorToRed(registerView.email);
            isValidemail = false;
        }
        CheckForFieldsValidation();
    }

    public void CityValidation()
    {
        city = registerView.city.text;
        if (city.Length >= 1)
        {
            SetColorToGreen(registerView.city);
            isValidcity = true;
        }
        else
        {
            SetColorToRed(registerView.city);
            isValidcity = false;
        }
        CheckForFieldsValidation();
    }


    public void CityCodeValidation()
    {
        cityCode = registerView.cityCode.text;
        if (cityCode.Length >= 5)
        {
            SetColorToGreen(registerView.cityCode);
            isValidcityCode = true;
        }
        else
        {
            SetColorToRed(registerView.cityCode);
            isValidcityCode = false;
        }
        CheckForFieldsValidation();
    }

	public void PasswordValidation()
    {
        Debug.Log("pass");
        password = registerView.password.text;
        rePassword = registerView.rePassword.text;

        if (password != rePassword)
        {
            SetColorToRed(registerView.rePassword);
            isValidrePassword = false;
        }
        else
        {
            SetColorToGreen(registerView.rePassword);
            isValidrePassword = true;
        }    
        
        if (password.Length >= 8 || password.Contains("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{7,15})$)"))
        {
            SetColorToGreen(registerView.password);
            isValidpassword = true;
        }
        else
        {
            SetColorToRed(registerView.password);
            isValidpassword = false;
        }
        CheckForFieldsValidation();


    }

    

    private void SetColorToGreen(InputField inputRef)
    {
        ColorBlock tempCb = new ColorBlock();
        tempCb.normalColor = Color.green;
        tempCb.highlightedColor = Color.green;
        tempCb.pressedColor = Color.green;
        tempCb.colorMultiplier = 1f;
        inputRef.colors = tempCb;
    }

    private void SetColorToRed(InputField inputRef)
    {
        ColorBlock tempCb = new ColorBlock();
        tempCb.normalColor = Color.red;
        tempCb.highlightedColor = Color.red;
        tempCb.pressedColor = Color.red;
        tempCb.colorMultiplier = 1f;
        inputRef.colors = tempCb;
    }

	public void AddClient()
    {
        registerView.registerWindow.SetActive(false);
        ClientElementModel latestUser = new ClientElementModel(id,email,password,userName,lastName,city,cityCode,streetName,streetNumber,"client");
        string folder = Application.dataPath + "/StreamingAssets";
        string fileName = "ClientsData.json";
        string fullPath = Path.Combine(folder, fileName);
        string jasonString = File.ReadAllText(fullPath);
        ClientModel tempUsers = JsonUtility.FromJson<ClientModel>(jasonString);
        int tempID = tempUsers.userList.Count;
        latestUser.id = tempID;       
        tempUsers.userList.Add(latestUser);
        string json = JsonUtility.ToJson(tempUsers);
        File.WriteAllText(fullPath, json);
    }

    public void CheckForFieldsValidation()
    {
        if(isValidemail == true && isValidpassword == true && isValidrePassword == true && isValiduserName == true 
            && isValidlastName == true && isValidcity == true && isValidcityCode == true && isValidstreetName == true && isValidstreetNumber == true)
        {
            registerView.registerButton.interactable = true;
        }
        else
        {
            registerView.registerButton.interactable = false;
        }
    }

}
