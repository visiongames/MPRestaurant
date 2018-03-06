using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ProductElementModel
{

    public int productId;
    public string productName;
    public float productPrice;
    public string productType;
    public int productQuantity;
    public List<ProductAdditionModel> listOfProductAddition;

    public ProductElementModel()
    {
        listOfProductAddition = new List<ProductAdditionModel>();
        
    }
    public ProductElementModel(int _productId, string _productName, float _productPrice, string _productType, int _productQuantity, List<ProductAdditionModel> _listOfProductAddition)
    {
        this.productId = _productId;
        this.productName = _productName;
        this.productPrice = _productPrice;
        this.productType = _productType;
        this.productQuantity = _productQuantity;
        this.listOfProductAddition = _listOfProductAddition;
    }
}
