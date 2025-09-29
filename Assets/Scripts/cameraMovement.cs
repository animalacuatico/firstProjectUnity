using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    public float mouseSens = 1000f;
    private float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Mantiene el cursor en el centro de la pantalla.
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRotation -= mouseY;
        if (yRotation >= 90) // Bloquea la rotación de la pantalla al mirar demasiado hacia arriba.
        {
            yRotation = 90;
        }
        if (yRotation <= -90) // Bloquea la rotación de la pantalla al mirar demasiado hacia abajo.
        {
            yRotation = -90;
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(yRotation, 0, 0), 1); // Lerp suaviza el movimiento de la cámara.
        player.transform.Rotate(Vector3.up * mouseX);
    }
}
