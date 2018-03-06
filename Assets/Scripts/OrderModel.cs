using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class OrderModel{

    public int orderId;
    public List<OrderElementModel> listOfClientOrder;
	public OrderModel()
    {
        listOfClientOrder = new List<OrderElementModel>();
    }
    public OrderModel(int _orderId, List<OrderElementModel> _listOfClientOrder)
    {
        this.orderId = _orderId;
        this.listOfClientOrder = _listOfClientOrder;
    }
}
