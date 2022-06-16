using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPizzaBoundry : MonoBehaviour
{
    public static bool inPaintableZone=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        inPaintableZone = true;
    }

    private void OnMouseExit()
    {
        inPaintableZone = false;
    }

}
