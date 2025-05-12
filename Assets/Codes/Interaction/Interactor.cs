using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
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
        if (collision.TryGetComponent(out I_Interactable Interactable) && Interactable.CanInteract())
        {
            // Sets the closest object as interactable
            InteractableInRange = Interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out I_Interactable Interactable) && Interactable == InteractableInRange)
        {
            // Sets nothing as interactable
            InteractableInRange = null;
        }
    }
}