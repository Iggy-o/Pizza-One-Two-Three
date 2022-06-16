using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour
{
    public GameObject[] cutLine;
    public GameObject[] checkMark;
    public static int cutChoiceNum;//how many lines chosen
    public static int cutChoicePortion;//how many portions sliced
    private int[] indexs= { -1, -1 };
    private int ind=0;
    private int cleanCheck = 0;
    public static int diffIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckSliceStatus();
        }

        if (cutChoiceNum == 2)
        {
            CheckSliceStatus();
        }
        else
        {
            Clean();
        }

    }

    public void CheckSliceStatus()
    {
        ind = 0;
        cutChoiceNum = 0;
        for (int i = 0; i < cutLine.Length; i++)
        {
            if (cutLine[i].name == "sliced")
            {
                indexs[ind] = i;
                ind++;
                cutChoiceNum++;
            }
        }
        for (int j = indexs[0]; j < indexs[1]; j++)
        {
            checkMark[j].SetActive(true);
            
        }
         //how many portions

        Debug.Log(cutChoiceNum);
        cutChoicePortion=(indexs[1]-indexs[0]);

    }

    public void Clean()
    {
        for (int i = 0; i < cutLine.Length; i++)
        {
            //cutLine[i].name = "notSliced";
            checkMark[i].SetActive(false);
        }
    }


}
