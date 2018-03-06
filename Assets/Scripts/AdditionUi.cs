using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionUi : MonoBehaviour {

    public int additionID;
    public GameObject additionParentRef;
    public Color baseColor;
    public bool isSelected;
    
    void Start()
    {
        baseColor = this.GetComponent<Image>().color;
        isSelected = false;
    }
    public void ClickedOnAddition()
    {
        additionParentRef.GetComponent<MenuUiItem>().SetAddition(additionID);
        
        if (isSelected == true)
        {
            this.GetComponent<Image>().color = baseColor;
            
        }
        else if(isSelected == false)
        {
            this.GetComponent<Image>().color = Color.red;
            
        }
        isSelected = !isSelected;


    }
}
