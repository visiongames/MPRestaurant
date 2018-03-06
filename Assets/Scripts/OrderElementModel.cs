using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class OrderElementModel {
    public int orderId;
    public float orderSummary;
    public string orderDate;
    public string orderDescription;
    public bool isComplete;
    public List<ProductElementModel> listOfProductInOrder;

    public OrderElementModel()
    {
        this.listOfProductInOrder = new List<ProductElementModel>();
    }
    public OrderElementModel(int _orderId, float _orderSummary, string _orderDate, string _orderDescription, bool _isComplete, List<ProductElementModel> _listOfProductInOrder)
    {
        this.orderId = _orderId;
        this.orderSummary = _orderSummary;
        this.orderDate = _orderDate;
        this.orderDescription = _orderDescription;
        this.isComplete = _isComplete;
        this.listOfProductInOrder = _listOfProductInOrder;
    }
}
