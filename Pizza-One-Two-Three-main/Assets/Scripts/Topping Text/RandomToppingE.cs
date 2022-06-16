using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomToppingE : MonoBehaviour
{
    public RandomToppingM script;
    public static string randomTopping2;
    public static string toppingtextvar2;
    public void BtnAction()
    {
        PickRandomFromList2();
    }

    private void PickRandomFromList2()
    {
        string[] toppings2 = new string[] { "Cheese", "Olives" };
        string randomTopping2 = toppings2[Random.Range(0, toppings2.Length)];
        toppingtextvar2 = randomTopping2;
    }


}
