using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2f; // Rango de interacci�n
    private Transform playerCamera; // La c�mara del jugador

    void Start()
    {
        playerCamera = Camera.main.transform; // Obtener la c�mara principal
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                interactableObject.Interact();
            }
        }
    }
}
