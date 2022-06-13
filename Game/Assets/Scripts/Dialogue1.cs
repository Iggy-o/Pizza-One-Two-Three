using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; //reference tmpro to text component
    public string[] lines;
    public float textSpeed;
    public Animator customerAnimator;
    public Animator playerAnimator;
    public static bool conversationOver = false;

    public GameObject StartBG;
    public GameObject RegisterBG;
    public GameObject KithcenBG;

    public GameObject ingredientTable;
    public GameObject hand;
    public GameObject fork;

    public GameObject customer;

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
       
        if (textComponent.text == lines[index] && talkOder != 3) //means this sentense has been run completely
        {
            playerAnimator.SetBool("StillTalking", false); //stop talking animation
        }
        if (textComponent.text != lines[index] && talkOder != 3)
        {
            playerAnimator.SetBool("StillTalking", true);
        }
        

     
        if (textComponent.text == lines[index] && talkOder == 3) //means this sentense has been run completely
        {
            customerAnimator.SetBool("StillTalking", false); //stop talking animation
        }
        if (textComponent.text != lines[index] && talkOder == 3)
        {
            customerAnimator.SetBool("StillTalking", true);
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
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            if (talkOder == 1)
            {
                StartBG.SetActive(false);
                RegisterBG.SetActive(true);
                //customer.SetActive(false);
            }
            if (talkOder == 2)
            {
                customer.SetActive(true);
            }
            if (talkOder == 4)
            {
                RegisterBG.SetActive(false);
                KithcenBG.SetActive(true);
                customer.SetActive(false);
            }
            if (talkOder == 5)
            {                   
                ingredientTable.SetActive(true);
                hand.SetActive(true);
                fork.SetActive(true);
            }
            if (talkOder == 8)
            {
                KithcenBG.SetActive(false);
                StartBG.SetActive(true);
                customer.SetActive(false);

                ingredientTable.SetActive(false);
                hand.SetActive(false);
                fork.SetActive(false);
            }
        }
        else 
        {

            gameObject.SetActive(false);
            conversationOver = true;
        }
    }
}
