using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class sanityMeter : MonoBehaviour
{
    [SerializeField]
    GameObject sliderObj;
    public static Slider stt;


    void Start()
    {
        stt = sliderObj.GetComponent<Slider>();
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        while (stt.value > 0)
        {
            stt.value -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}
