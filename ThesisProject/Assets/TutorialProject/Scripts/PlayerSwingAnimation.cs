using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwingAnimation : MonoBehaviour
{
    Animator animator;
    PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void OnAttack(InputValue value)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("isSwinging");
        }
    }
}
