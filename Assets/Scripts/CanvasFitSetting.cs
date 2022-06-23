using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFitSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        cam.orthographicSize = 200;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        cam.aspect = 880 / height;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
