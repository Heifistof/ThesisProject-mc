using UnityEngine;

public class AnimationArmorStand : MonoBehaviour, IInteractable
{
    [SerializeField] Animator animator;
    private bool isGrown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator not found on this GameObject!");
        }
        else
        {
            Debug.Log("Animator successfully found!");
        }
        isGrown = false;
    }
    public void Interact()
    {
        //Debug.LogError("Interact");
        if (isGrown)
        {
            animator.SetTrigger("shrink");
            isGrown = false;
        }
        else
        {
            animator.SetTrigger("grow");
            isGrown = true;
        }
    }

}
