using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private bool inDialogue, isTyping;
    private Queue<SO_Dialogue.Info> dialogueQueue;
    private string completeString;
    [SerializeField] float textDelay;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        dialogueQueue = new Queue<SO_Dialogue.Info>();
    }
    private IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isTyping = true;    
        foreach(char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c;
        }
        isTyping = false;
    }
    private void DequeueDialogue()
    {
        if(isTyping)
        {
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        SO_Dialogue.Info info = dialogueQueue.Dequeue();
        completeString = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));       
    }
    public void QueueDialogue(SO_Dialogue dialogue)
    {
        if (inDialogue)
        {
            return;
        }
        dialogueBox.SetActive(true);
        inDialogue = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        dialogueQueue.Clear();
        foreach (SO_Dialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }
    private void OnInteract(InputValue value)
    {
        if(inDialogue)
        {
            DequeueDialogue();
        }
    }
    private void CompleteText()
    {
        dialogueText.text = completeString;
    }
    private void EndDialogue()
    {
        inDialogue = false;
        dialogueBox.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }
}
