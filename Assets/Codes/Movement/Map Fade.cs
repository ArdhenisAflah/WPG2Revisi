using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapFade : MonoBehaviour
{
    public GameObject Enable;
    public GameObject Disable;
    public GameObject Intereactor;

    private void OnTriggerExit2D(Collider2D Collide)
    {
        Enable.SetActive(true);
        Disable.SetActive(false);
        Intereactor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Collide)
    {
        Enable.SetActive(false);
        Disable.SetActive(true);
        Intereactor.SetActive(true);
    }
}
