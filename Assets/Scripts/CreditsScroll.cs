using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 0.08f; // velocidade da rolagem

    void Update()
    {
        // Move o texto para cima
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.localPosition.y > 1000f) // ajuste conforme o tamanho
            transform.localPosition = new Vector3(transform.localPosition.x, -500f, transform.localPosition.z);

    }
}
