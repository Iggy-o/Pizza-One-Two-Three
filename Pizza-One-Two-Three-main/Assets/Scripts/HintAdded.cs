using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAdded : MonoBehaviour
{
    public GameObject textVal;

    // Start is called before the first frame update
    void Start()
    {
        textVal = GameObject.Find("HintText");
    }

    // Update is called once per frame
    void Update()
    {
        if (ToppingCounter.HintAdder == 1){ //Both right
            textVal.GetComponent<TMPro.TextMeshProUGUI>().text = "Nice work!";
        } 
        else if (ToppingCounter.HintAdder == 2){ //Topping right fraction not
            textVal.GetComponent<TMPro.TextMeshProUGUI>().text = "Fraction was wrong!";
        } 
        else if (ToppingCounter.HintAdder == 3){ //Fraction right topping not
            textVal.GetComponent<TMPro.TextMeshProUGUI>().text = "Topping was wrong!";
        } 
        else if (ToppingCounter.HintAdder == 4){ //Both wrong
            textVal.GetComponent<TMPro.TextMeshProUGUI>().text = "Not quite!";
        } 
        else Debug.Log("Error");
    }
}
