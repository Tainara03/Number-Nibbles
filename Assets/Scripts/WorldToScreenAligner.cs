using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class WorldToScreenAligner : MonoBehaviour
{
    public Transform target3DObject;
    public Camera uiCamera;

    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (uiCamera == null)
        {
            uiCamera = FindAnyObjectByType<Camera>();
        }
    }

    void Update()
    {
        if (target3DObject == null || uiCamera == null || canvas == null)
        {
            return;
        }

        Vector3 screenPoint = uiCamera.WorldToScreenPoint(target3DObject.position);

        if (screenPoint.z < 0)
        {
            rectTransform.anchoredPosition = new Vector2(9999, 9999);
            return;
        }

        Vector2 positionOnCanvas;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent.GetComponent<RectTransform>(), 
            screenPoint, 
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : uiCamera,
            out positionOnCanvas);

        rectTransform.anchoredPosition = positionOnCanvas;
    }
}