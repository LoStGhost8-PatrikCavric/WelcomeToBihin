using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public Sprite dialogueBoxSprite;
    public GameObject dialogueBox;
    public AudioSource audioSource;

    public AudioClip dialogueSound;

    public Dialog dialogue;
    public bool isDialogueTrigger = false;
    public bool isInDistance = false;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInDistance = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInDistance = false;
        
        FindObjectOfType<DialogueManager>().animator.SetBool("IsOpen", false);
        audioSource.Stop();
        isDialogueTrigger = false;
    }

    private void Update()
    {
        if (isInDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
                if (isDialogueTrigger)
                {
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                }
                else
                {
                    dialogueBox.transform.GetComponent<Image>().sprite = dialogueBoxSprite;
                    TriggerDialogue();
                    isDialogueTrigger = true;
                }
            }
            
        }

    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
