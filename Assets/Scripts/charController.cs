using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControllerv2 : MonoBehaviour
{
    public float playerSpeed = 10, gravForce = 0.8f;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z + transform.up * -gravForce;
        movement *= Time.deltaTime * playerSpeed;
        movement += transform.up * -gravForce * Time.deltaTime;
        controller.Move(movement);
    }
}
