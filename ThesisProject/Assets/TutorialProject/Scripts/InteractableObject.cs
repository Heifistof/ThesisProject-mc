using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] SO_Dialogue dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Interact()
    {
        DialogueManager.Instance.QueueDialogue(dialogue);
    }
}
