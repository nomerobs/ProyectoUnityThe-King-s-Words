using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorNormal;
    public static GameManager Instance;
    public int[] palabras;

    void Start()
    {
        Cursor.SetCursor(cursorNormal, new Vector2(128, 20), CursorMode.ForceSoftware);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
}
