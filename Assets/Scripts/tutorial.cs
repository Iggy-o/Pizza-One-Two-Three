using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] prompts;
    private int promptNum = 0;
    public KeyCode mouseLeft;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && promptNum < 6) {
            prompts[promptNum].SetActive(false);
            prompts[++promptNum].SetActive(true);
        } else if(Input.GetMouseButtonDown(0)) {
            prompts[promptNum].SetActive(false);
        }
    }
}
