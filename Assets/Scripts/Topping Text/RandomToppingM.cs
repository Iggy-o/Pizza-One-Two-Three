using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomToppingM : MonoBehaviour

{

    public Text toppingtext2;

    public void Start()
    {
        if (RandomToppingE.toppingtextvar2 != null)
        {
            toppingtext2.text = RandomToppingE.toppingtextvar2;
        }
        else
            toppingtext2.text = " ";
    }

    public void Update()
    {
        if (RandomToppingE.toppingtextvar2 != null)
        {
            toppingtext2.text = RandomToppingE.toppingtextvar2;
        }
        else
            toppingtext2.text = " ";
    }

}