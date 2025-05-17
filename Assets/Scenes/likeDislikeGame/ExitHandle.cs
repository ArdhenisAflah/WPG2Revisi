using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHandle : MonoBehaviour
{
    public GameObject panelFactChecker;
    public void OnClose()
    {
        panelFactChecker.SetActive(false);
    }
}
