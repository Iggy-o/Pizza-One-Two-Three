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

    private void OnMouseOver()
    {
        if (PaintPizza.toolType == "eraser")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(removeSound);
            Destroy(gameObject,0.4f);
            
        }
    }
}
