using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutterHover : MonoBehaviour
{
     public Texture2D cursorPizzaCutterPic;
    // Start is called before the first frame update
    void Start()
    {
         Cursor.SetCursor(cursorPizzaCutterPic, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
