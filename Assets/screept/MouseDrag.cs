
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            transform.position
        ).z;

        mOffset = transform.position - GetWorldMousePos();
    }

    private Vector3 GetWorldMousePos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetWorldMousePos() + mOffset;
    }
}
