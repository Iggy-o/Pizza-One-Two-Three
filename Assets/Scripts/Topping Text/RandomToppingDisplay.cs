using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RandomToppingDisplay : MonoBehaviour
{
    public RandomToppingLevel1 script;
    public static string randomTopping;
    public static string toppingtextvar;
    public void BtnAction()
    {
        PickRandomFromList();
    }

    private void PickRandomFromList()
    {
        string[] toppings = new string[] { "Tomato Sauce", "Pesto" };
        string randomTopping = toppings[Random.Range(0, toppings.Length)];
        toppingtextvar = randomTopping;

    }
    

}
