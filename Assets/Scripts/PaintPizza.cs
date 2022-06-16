using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPizza : MonoBehaviour
{

    public KeyCode mouseLeft;
    public static string toolType;
    public AudioClip addingSound;
    public static Transform thingsToPut;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePositions = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //get mouse position
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePositions); //adjust mouse position base on camera

        if (Input.GetKey(mouseLeft) && toolType == "addStuff" && PaintPizzaBoundry.inPaintableZone) //a single click 
        {
            Instantiate(thingsToPut, objPosition, thingsToPut.rotation);
            gameObject.GetComponent<AudioSource>().PlayOneShot(addingSound);

            if (thingsToPut.name == "GreenSauce 1"){
                ToppingCounter.pesto++;
            }
            else if (thingsToPut.name == "OliveSouce"){
                ToppingCounter.olives++;
            }
            else if (thingsToPut.name == "CheeseSauce 1"){
                ToppingCounter.cheese++;
            }
            else if (thingsToPut.name == "TomatoSouce"){
                ToppingCounter.tomato++;
            }
        }

    }


}
