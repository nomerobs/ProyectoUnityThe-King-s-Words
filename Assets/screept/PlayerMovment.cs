using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody RB;              
    private InputSystem_Actions input;
    public float forwardAcel;
    public float reverseAcel;
    public float maxSpeed;
    public float TurnStrength;

    private Vector2 dir;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {
        dir = input.Player.Move.ReadValue<Vector2>();

        float turn = -dir.x * TurnStrength * Time.deltaTime;
        transform.Rotate(0f, 0f, turn);

        // Seguir a la esfera
        transform.position = RB.transform.position;
    }

    private void FixedUpdate()
    {
        float accel = dir.y > 0 ? forwardAcel : reverseAcel;

        if (RB.linearVelocity.magnitude < maxSpeed)
        {
            RB.AddForce(transform.up * dir.y * accel * 1000f);
        }
    }

}