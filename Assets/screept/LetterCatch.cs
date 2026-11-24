using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterCatch : MonoBehaviour
{
    private InputSystem_Actions input;
   public GameManager manager;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }
    private void OnTriggerEnter(Collider other)
    {
        

    }
    private void OnTriggerStay(Collider other)
    {
        if (input.Player.Attack.IsPressed())
        {
            
            gameObject.SetActive(false);
            manager.minigame();

        }
    }
}
