using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private InputSystem_Actions input;
    private Rigidbody rb;

    public float maxSpeed = 6f;
    public float reverseMultiplier = 0.5f;
    public float acceleration = 30f;
    public float deceleration = 40f;
    public float turnSpeed = 220f;

    private Vector2 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        input = new InputSystem_Actions();
        input.Enable();
    }

    private void Update()
    {
        dir = input.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Giro
        float turn = -dir.x * turnSpeed * Time.fixedDeltaTime;
        Quaternion newRotation = rb.rotation * Quaternion.Euler(0f, 0f, turn);
        rb.MoveRotation(newRotation);

        // Dirección de avance aplanada: nunca apunta hacia arriba ni hacia abajo
        Vector3 forward = Vector3.ProjectOnPlane(newRotation * Vector3.up, Vector3.up).normalized;

        // Velocidad objetivo (solo horizontal)
        float speed = dir.y > 0 ? maxSpeed : maxSpeed * reverseMultiplier;
        Vector3 targetVelocity = forward * dir.y * speed;

        // Separamos la velocidad vertical para no tocarla
        Vector3 velocity = rb.linearVelocity;
        Vector3 horizontal = new Vector3(velocity.x, 0f, velocity.z);

        float rate = dir.y != 0 ? acceleration : deceleration;
        horizontal = Vector3.MoveTowards(horizontal, targetVelocity, rate * Time.fixedDeltaTime);

        rb.linearVelocity = new Vector3(horizontal.x, velocity.y, horizontal.z);
    }

    private void OnDestroy()
    {
        input.Disable();
    }
}