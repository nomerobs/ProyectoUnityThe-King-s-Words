using UnityEngine;

public class Door : MonoBehaviour
{
    public LetterCatch letter;

    private MeshRenderer meshRenderer;
    private Collider hitbox;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        hitbox = GetComponent<Collider>();
    }

    private void Update()
    {
        meshRenderer.enabled = !letter.good;
        hitbox.enabled = !letter.good;
    }
}
