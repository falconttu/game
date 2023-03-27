using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PlayerController;
    public float speed = 6f;

    [SerializeField]
    private float RotationSpeed = 10f;
    public Transform cam;
    public float SmoothTurnTime = 0.1f;
    float SmoothTurnVelocity;

    [SerializeField]
    private float gravity = -9.81f;

    private Vector3 velocity;

    [SerializeField]
    private Camera FollowCamera;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Gravity();
    }

    private void Move()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 MoveInput = Quaternion.Euler(0, FollowCamera.transform.eulerAngles.y, 0) * new Vector3(HorizontalInput, 0, VerticalInput);
        Vector3 MoveDirection = MoveInput.normalized;

        if (MoveDirection != Vector3.zero)
        {
            Quaternion DesiredRotation = Quaternion.LookRotation(MoveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, DesiredRotation, RotationSpeed * Time.deltaTime);
        }

        PlayerController.Move(MoveDirection * speed * Time.deltaTime);
    }

    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        PlayerController.Move(velocity * Time.deltaTime);
    }
}
