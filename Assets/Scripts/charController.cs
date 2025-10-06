using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControllerv2 : MonoBehaviour
{
    public float playerSpeed = 10, gravForce = -9.8f;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z + transform.up * gravForce;
        movement *= Time.deltaTime * playerSpeed;
        movement += transform.up * -gravForce * Time.deltaTime;
        controller.Move(movement);
    }
    // Ir a texturas Edit > Rendering > Convert para pasar texturas hechas en otra versión de Unity a una nueva.
    // Window > Package Manager > My Assets > Download and Import para meter assets de la Asset Store en Unity
    // Ir a las texturas y seleccionarlas, cambiarlas a Arnold
}
