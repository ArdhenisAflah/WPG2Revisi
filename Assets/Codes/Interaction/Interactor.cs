using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    private I_Interactable InteractableInRange = null;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && MinigameObject1.IsOpened == false)
        {
            // active
            MinigameObject1.IsOpened = true;
            // Check if Player presses Interact Key
            InteractableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.TryGetComponent(out I_Interactable Interactable) && Interactable.CanInteract())
        {
            // Debug.Log(MinigameObject1.IsOpened);
            // Sets the closest object as interactable
            InteractableInRange = Interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.TryGetComponent(out I_Interactable Interactable) && Interactable == InteractableInRange)
        {
            // Sets nothing as interactable
            InteractableInRange = null;
            MinigameObject1.IsOpened = false;
        }
    }
}