using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Script original de movimiento
    public float walkSpeed = 10, sprintSpeed = 20, jumpForce = 5000, jumps = 1, camSensitivity = 0.3f; // La sensibilidad de la cámara no tiene time * deltaTime.
    private Rigidbody rb;
    private Vector3 playerVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Forward
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) // Backwards
        {
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) // Left
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) // Right
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            jumps -= 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumps = 1;
    }
}
