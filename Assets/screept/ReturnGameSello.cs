using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnGameSello : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("MainGame");

    }
}
