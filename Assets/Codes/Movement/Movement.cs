using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour , I_Stairs
{
    [SerializeField]
    public float XSpeed = 8f;
    [SerializeField]
    public float YSpeed = 4f;
    private Vector2 moveSpeed;
    private Vector2 moveInput;
    private Rigidbody2D RbD;
    private Animator Animate;

    void Start()
    {
        // Insert x & y values into vector
        moveSpeed = new Vector2(XSpeed, YSpeed);

        // Get Rigidbody and Animator values
        RbD = GetComponent<Rigidbody2D>();
        Animate = GetComponent<Animator>();

        // Movement Tutorial
        // ?
    }

    public void StairsUp()
    {
        YSpeed = 1f;
    }
    public void StairsDown()
    {
        YSpeed = 9f;
    }
    public void StairsEnd()
    {
        YSpeed = 4f;
    }

    void Update()
    {
        // Insert x & y values into vector
        moveSpeed = new Vector2(XSpeed, YSpeed);

        // Set Rigicbody velocity value
        RbD.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Set IsWalking Boolean
        Animate.SetBool("IsWalking", true);

        if (context.canceled)
        {
            Animate.SetBool("IsWalking", false);
            Animate.SetFloat("LastInputX", moveInput.x);
            Animate.SetFloat("LastInputY", moveInput.y);
        }

        // Convert Player Inputs into vector values
            moveInput = context.ReadValue<Vector2>();

        // Set Input and LastInput Float
        Animate.SetFloat("InputX", moveInput.x);
        Animate.SetFloat("InputY", moveInput.y);
    }
}
