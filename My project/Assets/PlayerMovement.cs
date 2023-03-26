using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PlayerController;
    private float speed = 6f;

    [SerializeField]
    private float RotationSpeed = 10f;
    public Transform cam;
    public float SmoothTurnTime = 0.1f;
    float SmoothTurnVelocity;

    [SerializeField]
    private float gravity = -9.81f;
    private float GravityMultiply = 3.0f;

    private float velocity;
    private Vector3 Direction;

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
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 MoveInput = new Vector3(HorizontalInput, 0, VerticalInput);
        Vector3 MoveDirection = MoveInput.normalized;

        if (MoveDirection != Vector3.zero)
        {
            Quaternion DesiredRotation = Quaternion.LookRotation(MoveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, DesiredRotation, RotationSpeed * Time.deltaTime);
        }

        PlayerController.Move(MoveDirection * speed * Time.deltaTime);
    }
}
