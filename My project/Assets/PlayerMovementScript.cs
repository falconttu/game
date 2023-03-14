using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Mathf;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Refrencing the RigidBody
    Rigidbody rb;
    [SerializeField] float PlayerSpeed = 3f;
    [SerializeField] float JumpForce = 5f;
    [SerializeField] Transform Player;
    public CharacterController PlayerObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal and Vertical Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //PlayerObj.Move(direction * PlayerSpeed * Time.deltaTime);
        }

        rb.velocity = new Vector3(horizontal * PlayerSpeed, rb.velocity.y, vertical * PlayerSpeed);

        // Players Jumping Mechanic
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }

        // Crouching/Stealth Mechanic
        if (Input.GetKeyDown("ctrl"))
        {
            PlayerSpeed = 1f;
        }


    }
}
