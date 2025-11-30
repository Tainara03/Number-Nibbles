using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 80f; 
    public float pauseTime = 0.3f; 

    private RectTransform rectTransform;
    private float panelHeight;
    private float textHeight;
    private float pauseTimer = 0f;
    private bool isPaused = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (transform.parent != null)
        {
            RectTransform parentRect = transform.parent.GetComponent<RectTransform>();
            if (parentRect != null)
            {
                panelHeight = parentRect.rect.height;
            }
        }

        textHeight = rectTransform.rect.height;

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -panelHeight);
    }

    void Update()
    {
        if (isPaused)
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseTime)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -panelHeight);
                pauseTimer = 0f;
                isPaused = false;
            }
            return;
        }

        rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y >= textHeight + panelHeight)
        {
            isPaused = true;
        }
    }
}