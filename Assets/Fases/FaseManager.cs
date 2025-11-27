using UnityManager;

public class FaseManager : MonoBehaviour {
    public FaseData[] fases;
    public Transform mesa;
    public float distanciaEntreItens = 0.3f;
    private int faseAtual = 0;

    void Start()
    {
        CarregarFase(faseAtual);
    }

    public void CarregarFase(int index) {
        foreach (Transform child in mesa)
            Destroy(child.gameObject);

        FaseData fase = fases[index];
        
        for (int i = 0; i < fase.alimentos.Length; i++)
        {
            Vector3 pos = mesa.position + new Vector3(i * distanciaEntreItens, 0, 0);
            Instantiate(fase.alimentos[i], pos, Quaternion.identity, mesa);
        }
    }
    
    public void ProximaFase() {
        faseAtual++;
        if (faseAtual >= fases.Length)
            faseAtual = 0;
        
        CarregarFase(faseAtual);
    }
}