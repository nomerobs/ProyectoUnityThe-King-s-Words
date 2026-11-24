using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorNormal;
    public static GameManager Instance;
    public int[] palabras;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }


    private void Awake()
    {
        // Evitar duplicados
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void minigame()
    {
        Time.timeScale = 0f;
        Cursor.SetCursor(cursorNormal, new Vector2(128, 20), CursorMode.ForceSoftware);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void GameMain()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
