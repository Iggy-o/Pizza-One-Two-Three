using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomToppingLevel1 : MonoBehaviour

{

    public Text toppingtext;

    public void Start()
    {
        if (RandomToppingDisplay.toppingtextvar != null)
        {
            toppingtext.text = RandomToppingDisplay.toppingtextvar;
        }
        else
            toppingtext.text = "Tomato Sauce";
    }

    public void Update()
    {
        if (RandomToppingDisplay.toppingtextvar != null)
        {
            toppingtext.text = RandomToppingDisplay.toppingtextvar;
        }
        else
        toppingtext.text = "Tomato Sauce";
    }

}
    