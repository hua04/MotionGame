using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float coolDown;
    public float airMultiplier;
    public bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey= KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    public bool grounded;

    public Transform orientation;
    
    public float horizontalInput;
    public float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        
        MyInput();

        SpeedControl();

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
            Debug.Log("Grounded");
        }
        else
        {
            rb.drag = 0;
            
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //consider get key down for single jump & remove ready to jump
        if (Input.GetKey(jumpKey)&& readyToJump && grounded) 
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump),coolDown);
        }
    }

    private void MovePlayer()
    {
        //calculate Movement Direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f*airMultiplier, ForceMode.Force);
        }
        




    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized*moveSpeed;
            //limitVel=Vector3.ClampMagnitude(limitVel, moveSpeed);

            rb.velocity=new Vector3(limitVel.x, rb.velocity.y, limitVel.z);

            
        }
    }

    private void Jump()
    {
        //reset y velocity

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


        rb.AddForce(transform.up*jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;

    }
}
