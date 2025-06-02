using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapFade : MonoBehaviour
{
    public GameObject Enable;
    public GameObject Disable;
    public GameObject Interactor;

    private void OnTriggerExit2D(Collider2D Collide)
    {
        if (Collide.CompareTag("Player"))
        {
            Enable.SetActive(true);
            Disable.SetActive(false);
            Interactor.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D Collide)
    {
        if (Collide.CompareTag("Player"))
        {
            Enable.SetActive(false);
            Disable.SetActive(true);
            Interactor.SetActive(true);
        }
    }
}
