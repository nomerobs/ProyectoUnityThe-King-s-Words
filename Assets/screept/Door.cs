using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager manager;

    private void Update()
    {
        if (manager.IsCompleteW)
        {
            gameObject.SetActive(false);
        }
    }
}
