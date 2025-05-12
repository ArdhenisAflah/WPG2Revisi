using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private I_Tutorial TriggerInRange = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out I_Tutorial Trigger) && Trigger.CanShow() == true)
        {
            // Sets the closest object as Trigger
            TriggerInRange = Trigger;

            // Call the closest object
            TriggerInRange?.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out I_Interactable Trigger) && Trigger == TriggerInRange)
        {
            // Sets nothing as Trigger
            TriggerInRange = null;
        }
    }
}