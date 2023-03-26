using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    [SerializeField]
    private float MouseSense = 3.0f;

    private float rotationX;
    private float rotationY;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float DistanceFromTarget = 3.0f;

    private Vector3 CurrentRotation;
    private Vector3 SmoothVelocity = Vector3.zero;

    [SerializeField]
    private float SmoothTime = 0.2f;

    [SerializeField]
    private Vector2 RotationMinMax = new Vector2(-40, 40);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse Y") * MouseSense;
        float MouseY = Input.GetAxis("Mouse X") * MouseSense;

        rotationX += MouseX;
        rotationY += MouseY;

        // Clamping for x rotation
        rotationX = Mathf.Clamp(rotationX, RotationMinMax.x, RotationMinMax.y);
        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        // Apply damping between rotation changes
        CurrentRotation = Vector3.SmoothDamp(CurrentRotation, nextRotation, ref SmoothVelocity, SmoothTime);
        transform.localEulerAngles = CurrentRotation;

        // Substract forward vector of game object to point its forward vector to the target
        transform.position = target.position - transform.forward * DistanceFromTarget;
    }
}

