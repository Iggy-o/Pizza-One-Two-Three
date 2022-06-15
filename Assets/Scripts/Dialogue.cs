using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; //reference tmpro to text component
    public string[] lines;
    public float textSpeed;
    public Animator customerAnimator;
    public Animator playerAnimator;

    public GameObject continueButton;
    public GameObject[] BGPic;
    private int indexBG;
    public static bool conversationOver = false;
    private int index;
    private int talkOder = 0;
    // Start is called before the first frame update
    void Start()
    {
        conversationOver = false;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        SentenceBehaviour();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            indexBG++;
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
        }
        else 
        {
            continueButton.SetActive(true);
            gameObject.SetActive(false);
            conversationOver = true;
        }
    }

    public void SentenceBehaviour()
    {
        //BGPic[indexBG];
        if (textComponent.text == lines[index] && talkOder % 2 == 1) //means this sentense has been run completely
        {
            customerAnimator.SetBool("StillTalking", false); //stop talking animation
        }
        if (textComponent.text != lines[index] && talkOder % 2 == 1)
        {
            customerAnimator.SetBool("StillTalking", true);
        }



        if (textComponent.text == lines[index] && talkOder % 2 == 0) //means this sentense has been run completely
        {
            playerAnimator.SetBool("StillTalking", false); //stop talking animation
        }
        if (textComponent.text != lines[index] && talkOder % 2 == 0)
        {
            playerAnimator.SetBool("StillTalking", true);
        }



        if (Input.GetMouseButtonDown(0))
        {

            if (textComponent.text == lines[index]) //means this sentense has been run completely
            {
                NextLine();
                talkOder++;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index]; //instantly fill out the words in the sentense
            }
        }
    }
}
