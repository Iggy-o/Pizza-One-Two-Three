using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopToCut : MonoBehaviour
{
    public GameObject cutCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartToCut()
    {
        cutCanvas.SetActive(true);
        gameObject.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); //change the cursor to default arrow
        PaintPizza.toolType = ""; //clean up the tool type
    }
}
