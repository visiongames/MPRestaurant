using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ProductModel {

    public List<ProductElementModel> listOfAllProducts;

    public ProductModel()
    {
        listOfAllProducts = new List<ProductElementModel>();
    }
    public ProductModel(List<ProductElementModel> _listOfAllProducts)
    {
        this.listOfAllProducts = _listOfAllProducts;
    }
}
