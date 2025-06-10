using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSpeed : MonoBehaviour
{
    public I_Stairs StairsOn = null;

    public void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.TryGetComponent(out I_Stairs Stairs) && Collision.CompareTag("Player"))
        {
            StairsOn = Stairs;
            if (CompareTag("StairsUp"))
            {
                StairsOn?.StairsUp();
            }
            if (CompareTag("StairsDown"))
            {
                StairsOn?.StairsDown();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D Collision)
    {
        if (Collision.TryGetComponent(out I_Stairs Stairs) && Collision.CompareTag("Player"))
        {
            StairsOn?.StairsEnd();
        }
    }
}
