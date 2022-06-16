using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationOver1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue1.conversationOver == true)
        {
            gameObject.SetActive(false);
        }
    }
}
