using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody RB;
    private InputSystem_Actions input;
    public float forwardAcel;
    public float reverseAcel;
    public float maxSpeed;
    public float TurnStrength;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = RB.transform.position;
    }
    private void FixedUpdate()
    {
        Vector2 dir = input.Player.Move.ReadValue<Vector2>();

        RB.AddForce(transform.forward * forwardAcel * dir.y * 1000f);

        RB.MoveRotation(
    RB.rotation * Quaternion.Euler(
        0f,
        dir.x * TurnStrength * Time.fixedDeltaTime,
        0f
    )
);
    }
}
