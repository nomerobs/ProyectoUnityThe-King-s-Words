using TMPro;
using UnityEngine;

public class DetectorPalabras : MonoBehaviour
{
    public GameManager Manager;
    public void Mover()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Manager.palabras[1] = int.Parse(other.gameObject.name);
    }
}
