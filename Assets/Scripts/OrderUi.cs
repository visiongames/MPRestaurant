using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUi : MonoBehaviour {

    public Text orderPrice;
    public Text orderId;
    public OrderElementModel currentOrderData;
    public void SetOrderUi(OrderElementModel _currentOrderData)
    {
        currentOrderData = _currentOrderData;
        orderPrice.text = currentOrderData.orderSummary.ToString();
        orderId.text = currentOrderData.orderId.ToString();
    }
}
