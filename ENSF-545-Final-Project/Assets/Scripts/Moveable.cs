using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moveable : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1;
    private float initialSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSpeed = speed;
    }

    void OnMove(InputValue movementValue)
    {
        ChangeDirection(movementValue.Get<Vector2>());
    }

    void ChangeDirection(Vector2 movementVector)
    {
        movementX = movementVector.x;
        movementY = movementVector.y;
        speed = initialSpeed;

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if(speed > 0)
        {
            speed -= 0.2f;
        }
    }
}
