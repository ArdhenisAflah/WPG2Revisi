using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float moveSpeed = 5f;
    private Vector3 input;
    private Vector3 moveDirection;
    
    void Update()
    {
        // Get input
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down

        // Convert input to isometric movement
        input = new Vector3(horizontal, vertical, 0).normalized;

        // Convert to isometric direction
        // moveDirection = new Vector3(input.x - input.y, (input.x + input.y) / 2, 0);
        // moveDirection = new Vector2(horizontal, );
        
        // Move the character
        transform.position += input * moveSpeed * Time.deltaTime;
    }
}
