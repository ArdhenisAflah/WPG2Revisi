using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float XSpeed = 8f;
    [SerializeField]
    public float YSpeed = 4f;
    private Vector2 moveSpeed;
    private Vector2 moveInput;
    private Rigidbody2D RbD;

    void Start()
    {
        // Insert x & y values into vector
        moveSpeed = new Vector2(XSpeed, YSpeed);

        // Get Rigidbody values
        RbD = GetComponent<Rigidbody2D>();

        // Movement Tutorial
        // ?
    }

    private void OnTriggerEnter2D(Collider2D Collide)
    {
        if (Collide.CompareTag("StairsDown"))
        {
            YSpeed = 8;
        }

        if (Collide.CompareTag("StairsUp"))
        {
            YSpeed = 1;
        }
    }
    
    private void OnTriggerExit2D(Collider2D Collide)
    {
        if (Collide.CompareTag("StairsDown"))
        {
            YSpeed = 4;
        }

        if (Collide.CompareTag("StairsUp"))
        {
            YSpeed = 4;
        }
    }

    void Update()
    {
        // Set Rigicbody velocity value
        RbD.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Convert Player Inputs into vector values
        moveInput = context.ReadValue<Vector2>();
    }
}
