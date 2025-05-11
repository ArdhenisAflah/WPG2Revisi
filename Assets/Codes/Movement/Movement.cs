using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] 
    private float XSpeed = 8f;
    [SerializeField] 
    private float YSpeed = 4f;
    private Vector2 moveSpeed;
    private Vector2 moveInput;
    private Rigidbody2D RbD;

    void Start()
    {
        // Insert x & y values into vector
        moveSpeed = new Vector2(XSpeed,YSpeed);
        
        // Get Rigidbody values
        RbD = GetComponent<Rigidbody2D>();

        // Movement Tutorial
        // ?
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
