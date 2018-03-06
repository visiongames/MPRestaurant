using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ProductAdditionModel
{

    [SerializeField]private string additionName;
    [SerializeField]private int additionPrice;
    [SerializeField]private bool isSlected;
    public ProductAdditionModel()
    {

    }
    public ProductAdditionModel(string additionName, int _additionPrice, bool _isSlected)
    {
        AdditionName = additionName;
        AdditionPrice = _additionPrice;
        IsSelected = _isSlected;
    }
    public string AdditionName{ get { return additionName; } set { additionName = value; } }
    public bool IsSelected { get { return isSlected; } set { isSlected = value; } }
    public int AdditionPrice { get { return additionPrice; }
        set
        { if (additionPrice < 0)
            {
                additionPrice = 0;
            }
          else additionPrice = value;
        }
    }




}
