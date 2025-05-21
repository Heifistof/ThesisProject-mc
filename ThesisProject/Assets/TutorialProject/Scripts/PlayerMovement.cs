using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody characterRB;
    Vector3 movementInput, movementVector;
    bool isSprinting, isCrouching;

    [SerializeField] float movementSpeed, startMovementSpeed;

    Animator animator;
    void Start()
    {

        characterRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        startMovementSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSprinting)
        {
            movementSpeed = 300;
        }
        else if (isCrouching)
        {
            movementSpeed = 50;
        }
        else
        {
            movementSpeed = startMovementSpeed;
        }
        if (movementInput != null)
        {
            movementVector = (transform.right * movementInput.x) + (transform.forward * movementInput.z);
            movementVector.y = 0;
            movementVector *= (Time.fixedDeltaTime * movementSpeed);
        }
        movementVector.y = characterRB.linearVelocity.y;
        characterRB.linearVelocity = movementVector;

    }
    private void OnMovement(InputValue input)//namnge metoderna rätt för den fattar själv
    {
        movementInput = new Vector3(input.Get<Vector2>().x,0, input.Get<Vector2>().y);
        animator.SetBool("isMoving", true);//string för att hitta boolen
    }
    private void OnMovementStop(InputValue input)
    {
        movementInput = Vector3.zero;
        animator.SetBool("isMoving", false);
    }
    private void OnJump()
    {
        characterRB.AddForce(0, 200, 0);
    }
    private void OnSprint()
    {
        if (!isSprinting)
        {
            isSprinting = true;
            isCrouching = false;
        }
        else
        {
            isSprinting = false;
        }
    }
    private void OnCrouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            isSprinting = false;
        }
        else
        {
            isCrouching = false;
        }
    }

}
