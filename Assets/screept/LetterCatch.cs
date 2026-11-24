using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterCatch : MonoBehaviour
{
    private InputSystem_Actions input;
    public GameManager manager;
    public GameObject MiniGame;

    public bool good;
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
            manager.minigame();
            MiniGame.SetActive(true);

        }
    }
    public void HideActivity()
    {
        MiniGame.SetActive(false);
    }
}
