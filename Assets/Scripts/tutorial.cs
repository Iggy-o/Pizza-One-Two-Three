using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] prompts;
    private int currentPrompt = 0;

    public void nextTextBox(){
        prompts[currentPrompt].SetActive(false);
        prompts[++currentPrompt].SetActive(true);
    }

    /*
    // Update is called once per frame
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && currentPrompt < 6) {
            prompts[currentPrompt].SetActive(false);
            prompts[++currentPrompt].SetActive(true);
        } else if(Input.GetMouseButtonDown(0)) {
            prompts[currentPrompt].SetActive(false);
        }
    }
    */
}
