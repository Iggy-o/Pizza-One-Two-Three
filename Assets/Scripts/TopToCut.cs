using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopToCut : MonoBehaviour
{
    public GameObject cutCanvas;
    public GameObject fork;
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        hand.SetActive(true);
        fork.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartToCut()
    {
        cutCanvas.SetActive(true);
        hand.SetActive(false);
        fork.SetActive(false); 
        gameObject.SetActive(false);

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); //change the cursor to default arrow
        PaintPizza.toolType = ""; //clean up the tool type
    }
}
