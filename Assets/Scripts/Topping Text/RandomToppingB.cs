using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomToppingB : MonoBehaviour
{
    public RandomToppingE script;

    public void BtnAction()
    {
        SetLevel1Topping2();
    }

    private void SetLevel1Topping2()
    {
        RandomToppingE.toppingtextvar2 = "Cheese";
    }

}
