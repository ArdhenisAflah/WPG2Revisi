using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitHandle : MonoBehaviour
{
    public GameObject PanelToDisable;
    public GameObject EmptyInputField;
    public void OnClose()
    {
        MinigameObject1.IsOpened = false;
        PanelToDisable.SetActive(false);
        if (EmptyInputField != null)
        {
            EmptyInputField.GetComponent<TMP_InputField>().text = "";
        }
    }
}
