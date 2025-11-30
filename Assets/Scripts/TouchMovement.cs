using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
