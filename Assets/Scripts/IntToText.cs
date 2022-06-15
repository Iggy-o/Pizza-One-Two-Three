using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntToText : MonoBehaviour
{
    public int value;
    public GameObject textVal;
    public GameObject LevelLoader;

    // Start is called before the first frame update
    void Start()
    {
        textVal = GameObject.Find("DayNumberText");
        value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        value = DayCustomerCheck.dayCount;
        textVal.GetComponent<TMPro.TextMeshProUGUI>().text = value.ToString();
    }
}
