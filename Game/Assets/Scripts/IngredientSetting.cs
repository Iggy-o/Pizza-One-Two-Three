using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSetting : MonoBehaviour
{
    public Transform defaultIngredient;
    // Start is called before the first frame update
    void Start()
    {
        PaintPizza.thingsToPut = defaultIngredient;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
