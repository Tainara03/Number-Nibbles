using UnityEngine;

public class DraggableItem3D : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;
    private float zCoord;
    private float fixedY = 0.5f;

    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 initialScale;
    [HideInInspector] public Transform originalParent;

    void Start()
    {
        cam = Camera.main;
        initialPosition = transform.position;
        originalParent = transform.parent;
        initialScale = transform.localScale;
    }

    void OnMouseDown()
    {
        if(cam == null) return;
        zCoord = cam.WorldToScreenPoint(transform.position).z;
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        offset = transform.position - cam.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if(cam == null) return;
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        Vector3 newPos = cam.ScreenToWorldPoint(mousePoint) + offset;
        transform.position = new Vector3(newPos.x, fixedY, newPos.z);
    }

    void OnMouseUp()
    {
        CupcakeMathManager manager = Object.FindFirstObjectByType<CupcakeMathManager>();
        if(manager != null)
            manager.UpdateCountDisplay();
    }
}
