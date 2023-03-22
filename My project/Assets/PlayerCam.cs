using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Initialising Transformation Variables
    public Transform orientation;
    public Transform Player;
    public Transform PlayerObj;

    public Rigidbody rb;
    public float RotationSpeed;
    public float PlayerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating the Orientation
        /*Vector3 ViewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orientation.forward = ViewDir.normalized;

        float HorizInput = Input.GetAxis("Horizontal");
        float VertInput = Input.GetAxis("Vertical");

        Vector3 InputDir = orientation.forward * VertInput + orientation.right * HorizInput;
        if (InputDir != Vector3.zero)
        {
            PlayerObj.forward = Vector3.Slerp(PlayerObj.forward, InputDir.normalized, Time.deltaTime * RotationSpeed);
        }*/
        SpeedControl();
    }

    private void SpeedControl()
    {
        Vector3 FlatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (FlatVel.magnitude > PlayerSpeed)
        {
            Vector3 LimVel = FlatVel.normalized * PlayerSpeed;
            rb.velocity = new Vector3(LimVel.x, rb.velocity.y, LimVel.z);
        }

    }
}
