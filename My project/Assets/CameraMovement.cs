using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;




public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform orientation;
    [SerializeField] Transform Player;
    [SerializeField] public Transform PlayerObj;
    [SerializeField] float RotationSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 InputDir = orientation.forward * HorizontalInput + orientation.forward * VerticalInput;

        if (InputDir != Vector3.zero)
        {
            PlayerObj.forward = Vector3.Slerp(PlayerObj.forward, InputDir.normalized, Time.deltaTime * RotationSpeed);
        }


    }
}
