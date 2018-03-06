using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
[Serializable]
public class ClientModel{

    public List<ClientElementModel> userList;


    public ClientModel()
    {
        userList = new List<ClientElementModel>();
    }
    public ClientModel(List<ClientElementModel> _userList)
    {
        this.userList = _userList;
    }

    
}
