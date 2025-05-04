using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBtn : MonoBehaviour
{
    public static event Action OnResetPressed;
    public void ResetButton()
    {
        OnResetPressed?.Invoke();
    }
}
