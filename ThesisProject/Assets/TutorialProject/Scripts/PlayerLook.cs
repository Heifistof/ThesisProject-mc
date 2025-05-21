using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerLook : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int mouseSensitivity;
    [SerializeField] Transform playerCamera;
    float xRotation, yRotation, mouseX, mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//set cursor to 0
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseY *= Time.deltaTime * mouseSensitivity;
        mouseX *= Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -35f, 70f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //roterar spelaren
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation,0); //roterar kameran

    }
    private void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }
}
