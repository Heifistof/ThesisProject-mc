using UnityEngine;
using UnityEngine.InputSystem;
public interface IInteractable
{
    void Interact();
}
public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float interactRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerCamera = GetComponent<Camera>();
        //if (playerCamera == null)
        //{
        //    Debug.LogError("No Camera component found on the same GameObject.");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnInteract(InputValue value)
    {
        //Debug.LogError("E");
        Ray ray = new Ray
        {
            origin = playerCamera.transform.position,
            direction = playerCamera.transform.forward
        };
        Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.green, 2.0f);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, interactRange))
        {
            IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                // Calling interact method of the interactable
                interactable.Interact();
            }
        }
    }
}
