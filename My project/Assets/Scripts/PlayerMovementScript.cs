using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Mathf;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Refrencing the RigidBody
    Rigidbody rb;
    [SerializeField] float PlayerSpeed;
    //[SerializeField] float SprintSpeed;

    public Transform Orientation;
    float horizontal;
    float vertical;
    Vector3 MoveDir;

    public float groundDrag;
    public float PlayerHeight;
    public LayerMask WhatIsGround;
    bool grounded;
    //public CharacterController PlayerObj;

    // Smooth Turning
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal and Vertical Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        MoveDir = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        rb.AddForce(MoveDir.normalized * PlayerSpeed * 10f, ForceMode.Force);
        // rb.velocity = new Vector3(horizontal * PlayerSpeed, rb.velocity.y, vertical * PlayerSpeed);

        // Players Jumping Mechanic
        /*if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }*/

        // Ground Checking
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, WhatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
        }

        else
        {
            rb.drag = 0;
        }
        // Players Sprinting Mechanic
        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SprintSpeed = 5f;
            rb.velocity = new Vector3(horizontal * SprintSpeed, rb.velocity.y, vertical * PlayerSpeed);
        }

        // Crouching/Stealth Mechanic
        if (Input.GetKeyDown("ctrl"))
        {
            PlayerSpeed = 1f;
        }*/


    }
}
