using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    // Variables de andar, correr, saltar, gravedad, distancia del suelo, y sensibilidad de la cámara.
    public float walkSpeed = 5f, runSpeed = 8f, jumpHeight = 2f, gravity = -9.81f, groundDistance = 0.4f, mouseSens = 2f;
    public Transform playerCamera;
    public LayerMask groundMask = 1;
    // Variables privadas.
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Transform groundCheck;
    // Mouse look variables.
    private float xRotation = 0f;
    private float mouseX, mouseY;
    // Movement variables.
    private bool isRunning;
    private float currentSpeed;
    private Vector3 move;
    private float x, y, z;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        CreateGroundCheck(); // Crear el objeto para comprobar si hay suelo, mediante un método.
        Cursor.lockState = CursorLockMode.Locked; // Para que el cursor se quede en el centro de la pantalla.
        if (playerCamera == null)
        {
            playerCamera = Camera.main?.transform;
            if (playerCamera == null)
            {
                Debug.LogError("No camera assigned or found."); // Da error si no se detecta una cámara unida al jugador.
            }
        }
    }
    void Update()
    {
        HandleGroundCheck();
        HandleMouseLook();
        HandleMovement();
        HandleJump();
        HandleGravity();
        controller.Move(move * Time.deltaTime); // Aplicar el movimiento.
    }
    void CreateGroundCheck()
    {
        // Crea un objeto vacío para comprobar el suelo.
        GameObject groundCheckObj = new GameObject("GroundCheck"); // Crear un objeto nuevo que se llame GroundCheck.
        groundCheckObj.transform.SetParent(transform); // Haz que el player sea el padre del objeto nuevo.
        groundCheckObj.transform.localPosition = new Vector3(0, -controller.height / 2f, 0); // Hace que la posición del objeto vacío sea negativa a la altura del objeto, para que este a los pies del objeto.
        groundCheck = groundCheckObj.transform; // Llama a la variable Transform groundCheck y le pasa la información a la variable.
    }
    void HandleGroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // Comprueba si está en el suelo casteando un raycast esférico.
        if (isGrounded && velocity.y < 0) // Si estamos cayendo, para no atravesar el suelo.
        {
            velocity.y = -2f; // Valor pequeño negativo para que se mantenga en el suelo.
        }
    }
    void HandleMouseLook()
    {
        if (playerCamera == null)
        {
            return;
        }
        // Obtener input del ratón.
        mouseX = Input.GetAxis("Mouse X") * mouseSens;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens;
        // Rotar la cámara arriba y abajo.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Para tener un límite y que no te puedas desnucar al mirar hacia arriba o abajo.
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotar el jugador de izquierda a derecha.
        transform.Rotate(Vector3.up * mouseX);
    }
    void HandleMovement()
    {
        // Obtener el input.
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        // Comprobar si está corriendo.
        isRunning = Input.GetKey(KeyCode.LeftShift);
        currentSpeed = isRunning ? runSpeed : walkSpeed;
        // Calcular la dirección del movimiento relativa al jugador.
        move = transform.right * x + transform.forward * z;
        move = Vector3.ClampMagnitude(move, 1f) * currentSpeed;
        // Añadir velocidad vertical
        move.y = velocity.y;
    }
    void HandleJump()
    {
        // Saltar cuando presionas espacio y se encuentra en el suelo.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Para que vaya frenando y cree una parábola para que no suba infinitamente al cielo.
        }
    }
    void HandleGravity()
    {
        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawSphere(groundCheck.position, groundDistance);
        }
    }
    // Métodos públicos para control externo.
    public bool IsGrounded => IsGrounded;
    public bool IsRunning => isRunning;
    public float CurrentSpeed => currentSpeed;
    public Vector3 Velocity => controller.velocity;
    // Método para togglear el cursor, útil para menus de pausa.
    public void ToggleCursorLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
