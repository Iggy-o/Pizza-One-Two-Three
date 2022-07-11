using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolControler : MonoBehaviour
{

    public Texture2D cursorHandPic;
    public Texture2D cursorForkPic;
    
    //new added stuff
    SpriteRenderer sprite;
    public GameObject othersprite;


    public KeyCode mouseLeft;

    // Start is called before the first frame update
    void Start()
    {
        //new added stuff
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resetImage(){
        sprite.color = new Color(1,1, 1, 1);
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "fork")
        {
            PaintPizza.toolType = "eraser";
            Cursor.SetCursor(cursorForkPic, Vector2.zero, CursorMode.ForceSoftware);

            //new added stuff
            sprite.color = new Color(1, 1, 0, 1);
            othersprite.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        if (gameObject.name == "hand")
        {
            PaintPizza.toolType = "addStuff";
            Cursor.SetCursor(cursorHandPic, Vector2.zero, CursorMode.ForceSoftware);

            //new added stuff
            sprite.color = new Color(1, 1, 0, 1);
            othersprite.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
    }
}
