using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolControler : MonoBehaviour
{

    public Texture2D cursorHandPic;
    public Texture2D cursorForkPic;

    
    public KeyCode mouseLeft;
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
        if (gameObject.name == "fork")
        {
            PaintPizza.toolType = "eraser";
            Cursor.SetCursor(cursorForkPic, Vector2.zero, CursorMode.ForceSoftware);
        }
        if (gameObject.name == "hand")
        {
            PaintPizza.toolType = "addStuff";
            Cursor.SetCursor(cursorHandPic, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
