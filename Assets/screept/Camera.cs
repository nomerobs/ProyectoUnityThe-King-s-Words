using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Camera : MonoBehaviour
{
    public Rigidbody RB; 
    private InputSystem_Actions input;
    float sensibility = 10;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }
    void Update()
    {
        transform.position = RB.transform.position;

        float mouseX = Mouse.current.delta.x.ReadValue();
        float mouseY = -Mouse.current.delta.y.ReadValue();


        transform.localEulerAngles += new Vector3(mouseY, mouseX, 0) * sensibility * Time.deltaTime;

        Vector3 rotation = transform.localEulerAngles;


        transform.localEulerAngles = rotation;
    }
}
