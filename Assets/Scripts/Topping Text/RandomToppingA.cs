using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomToppingA : MonoBehaviour
{
    public RandomToppingDisplay script;

    public void BtnAction()
    {
        SetLevel1Topping();
    }

    private void SetLevel1Topping()
    {
        RandomToppingDisplay.toppingtextvar = "Tomato Sauce";
    }
}

