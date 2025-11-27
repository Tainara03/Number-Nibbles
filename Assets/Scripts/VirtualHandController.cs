using UnityEngine;

public class VirtualHandController : MonoBehaviour
{
    public float moveSpeed = 2f;       // Velocidade de movimento
    public float rotationSpeed = 80f;  // Velocidade de rotação
    public float zoomSpeed = 2f;       // Velocidade de aproximação/afastamento

    void Update()
    {
        MoveVirtualHand();
        RotateVirtualHand();
        ZoomVirtualHand();
    }

    void MoveVirtualHand()
    {
        // Movimento horizontal e vertical (setas ou WASD)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, moveY, 0), Space.World);
    }

    void RotateVirtualHand()
    {
        // Rotaciona com o botão direito do mouse
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -rotX, Space.World);
            transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }

    void ZoomVirtualHand()
    {
        // Zoom com a roda do mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);
    }
}
