using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    [SerializeField]
    private float RotationSpeed = 10f;

    public Transform cam;
    public float turnsmoothtime = 0.1f;
    float turnsmoothvelocity;

    private float gravity = -9.81f;
    [SerializeField] private float GravityMultiplier = 3.0f;
    private float velocity;
    private Vector3 direction;

    [SerializeField]
    private Camera FollowCamera;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        Rotation_Movement();

    }

    private void Rotation_Movement()
    {
        float HoriInput = Input.GetAxis("Horizontal");
        float VertiInput = Input.GetAxis("Vertical");

        Vector3 MovementInput = Quaternion.Euler(0, FollowCamera.transform.eulerAngles.y, 0) * new Vector3(HoriInput, 0, VertiInput);
        Vector3 MovementDirection = MovementInput.normalized;


        if (MovementDirection != Vector3.zero)
        {
            Quaternion DesiredRotation = Quaternion.LookRotation(MovementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, DesiredRotation, RotationSpeed * Time.deltaTime);
        }

        controller.Move(MovementDirection * speed * Time.deltaTime);
    }

    private void Gravity()
    {
        velocity += gravity * GravityMultiplier * Time.deltaTime;
        direction.y = velocity;
    }
}

