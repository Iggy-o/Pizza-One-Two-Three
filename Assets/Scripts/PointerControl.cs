using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerControl : MonoBehaviour
{
    public AudioClip removeSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (PaintPizza.toolType == "eraser")
        {
            if (gameObject.transform.name == "GreenSauce 1(Clone)"){
                ToppingCounter.pesto--;
            }
            else if (gameObject.transform.name == "OliveSouce(Clone)"){
                ToppingCounter.olives--;
            }
            else if (gameObject.transform.name == "CheeseSauce 1(Clone)"){
                ToppingCounter.cheese--;
            }
            else if (gameObject.transform.name == "TomatoSouce(Clone)"){
                ToppingCounter.tomato--;
            }

            gameObject.GetComponent<AudioSource>().PlayOneShot(removeSound);
            Destroy(gameObject,0.4f);
            
        }
    }
}
