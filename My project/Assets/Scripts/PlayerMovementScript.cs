using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Mathf;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class PlayerMovementScript : MonoBehaviour
{
    // Refrencing the RigidBody
    [SerializeField] float PlayerSpeed = 5f;

    [Header("CharacterController")]
    public CharacterController controller;
    public Transform Cam;
    Vector3 MoveDir;
    float verticalInput;
    float horizontalInput;

    [Header("SmoothTurning")]
    public float SmoothTurnTime = 0.1f;
    float SmoothTurnVelocity;

    // Smooth Turning
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Horizontal and Vertical Movement
        MovementControl();




        //MoveDir = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        //rb.AddForce(MoveDir.normalized * PlayerSpeed * 10f, ForceMode.Force);
        // rb.velocity = new Vector3(horizontal * PlayerSpeed, rb.velocity.y, vertical * PlayerSpeed);*/
    }

    private void MovementControl()
    {
        // Horizontal and Vertical Movement
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(HorizontalInput * PlayerSpeed, rb.velocity.y, VerticalInput * PlayerSpeed);

        // Movement Direction
        Vector3 Direction = new Vector3(HorizontalInput, 0f, VerticalInput).normalized;
        if (Direction.magnitude >= 0.1f)
        {
            float TargetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref SmoothTurnVelocity, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            Vector3 MoveDir = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            controller.Move(MoveDir.normalized * PlayerSpeed * Time.deltaTime);
        }
    }

}
