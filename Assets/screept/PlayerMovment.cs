
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private InputSystem_Actions input;
    private Rigidbody rb;

    public float forwardAcel;
    public float reverseAcel;
    public float maxSpeed;
    public float TurnStrength;

    private Vector2 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {
        dir = input.Player.Move.ReadValue<Vector2>();

        float turn = -dir.x * TurnStrength * Time.deltaTime;
        transform.Rotate(0f, 0f, turn);
    }

    private void FixedUpdate()
    {
        float accel = dir.y > 0 ? forwardAcel : reverseAcel;
        
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.up * dir.y * accel * 1000f);
        }

    }

    private void OnDestroy()
    {
        input.Disable();
    }
}
