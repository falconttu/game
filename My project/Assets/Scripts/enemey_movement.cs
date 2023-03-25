using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey_movement : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 5.0f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool isMovingToEndPosition = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0.0f, 0.0f, distance);
    }

    void Update()
    {
        if (isMovingToEndPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

            if (transform.position == endPosition)
            {
                isMovingToEndPosition = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            if (transform.position == startPosition)
            {
                isMovingToEndPosition = true;
            }
        }
    }
}