using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceStuff : MonoBehaviour
{
    public static string statusCut = "no";
    SpriteRenderer renderer ;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameObject.name == "notSliced"&&Slice.cutChoiceNum<2)
        {
            gameObject.name = "sliced";
            renderer.color = new Color(0f, 0f, 0f, 1f);
            Slice.cutChoiceNum++;
            statusCut = "yes";
            //Debug.Log("it's been changed to yes");
        }
        else if (gameObject.name == "sliced")
        {
            gameObject.name = "notSliced";
            renderer.color = new Color(1f, 1f, 1f, 1f);
            Slice.cutChoiceNum--;
            statusCut = "no";
            //Debug.Log("it's been changed to no");
        }
    }
}
