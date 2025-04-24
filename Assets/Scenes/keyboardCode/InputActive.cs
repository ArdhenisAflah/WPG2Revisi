using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InputActive : MonoBehaviour
{
    public TMP_InputField inpfield1;
    public GameObject keyboard;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            inpfield1.Select();
            inpfield1.ActivateInputField();
        }

    }
}
