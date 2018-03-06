using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ClientElementModel{

    public int id;
    public string email;
    public string password;
    public string userName;
    public string lastName;
    public string city;
    public string cityCode;
    public string streetName;
    public string streetNumber;
    public string userType;
    public List<OrderElementModel> userOrders;
    public ClientElementModel()
    {
        userOrders = new List<OrderElementModel>();
    }
    public ClientElementModel(int _id, string _email, string _password,
        string _userName, string _lastName, string _city, string _cityCode, string _streetName, string _streetNumber, string _userType)
    {
        this.id = _id;
        this.email = _email;
        this.password = _password;
        this.userName = _userName;
        this.lastName = _lastName;
        this.city = _city;
        this.cityCode = _cityCode;
        this.streetName = _streetName;
        this.streetNumber = _streetNumber;
        this.userType = _userType;
        
    }
    public ClientElementModel(List<OrderElementModel> _userOrders)
    {
        userOrders = new List<OrderElementModel>();
        this.userOrders = _userOrders;
    }

}
