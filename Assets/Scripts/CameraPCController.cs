using UnityEngine;

public class CameraPCController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        // Movimento WASD
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S
        transform.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);

        // Rotação com mouse
        yaw += lookSpeed * Input.GetAxis("Mouse X");
        pitch -= lookSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
