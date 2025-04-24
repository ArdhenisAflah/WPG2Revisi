using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class keytyping : MonoBehaviour
{
    public Sprite keyPressed;
    public Sprite keyUnpress;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // ganti png sprite to pressed
            this.gameObject.GetComponent<SpriteRenderer>().sprite = keyPressed;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            //ganti png sprite to normal
            this.gameObject.GetComponent<SpriteRenderer>().sprite = keyUnpress;
        }
    }
}
