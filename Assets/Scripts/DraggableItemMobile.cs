using UnityEngine;

public class DraggableItemMobileAR : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;
    private Camera cam;

    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 initialScale;

    [Header("Mesa AR")]
    public Transform tableTransform;

    private float tableHeight;

    void Start()
    {
        cam = Camera.main;
        initialPosition = transform.position;
        initialScale = transform.localScale;

        if (tableTransform != null)
        {
            tableHeight = tableTransform.position.y + 0.05f;
        }
        else
        {
            tableHeight = transform.position.y;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Ray ray = cam.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.transform == transform)
                        {
                            zCoord = cam.WorldToScreenPoint(transform.position).z;
                            Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, zCoord));
                            offset = transform.position - worldPoint;
                            isDragging = true;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector3 newPos = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, zCoord)) + offset;
                        transform.position = new Vector3(newPos.x, tableHeight, newPos.z);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (isDragging)
                    {
                        isDragging = false;
                        CupcakeMathManager manager = Object.FindFirstObjectByType<CupcakeMathManager>();
                        if (manager != null)
                            manager.TrySnapToPlate(this.gameObject);
                    }
                    break;
            }
        }
    }
}
