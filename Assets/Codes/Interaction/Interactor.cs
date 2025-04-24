using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private I_Interactable InteractableInRange = null;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Check if Player presses Interact Key
            InteractableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out I_Interactable interactable) && interactable.CanInteract())
        {
            // Sets the closest object as interactable
            InteractableInRange = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out I_Interactable interactable) && interactable == InteractableInRange)
        {
            // Sets nothing as interactable
            InteractableInRange = null;
        }
    }
}