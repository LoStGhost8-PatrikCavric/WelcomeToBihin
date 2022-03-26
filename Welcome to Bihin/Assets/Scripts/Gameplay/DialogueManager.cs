using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;

    public Queue<string> text;
    public Text nameText;
    public Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        text = new Queue<string>();
    }

    public void StartDialogue(Dialog dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        text.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            text.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (text.Count == 0)
        {
            FindObjectOfType<NPCInteraction>().isDialogueTrigger = false;

            animator.SetBool("IsOpen", false);

            return;
        }

        string sentence = text.Dequeue();
        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        FindObjectOfType<NPCInteraction>().audioSource.Play();     

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.1f);
        }

        FindObjectOfType<NPCInteraction>().audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
