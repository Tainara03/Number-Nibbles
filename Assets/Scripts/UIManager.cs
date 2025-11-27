using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject creditsPanel;

    // Mostrar painel de créditos
    public void ShowCredits()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Voltar para o menu principal
    public void ShowMainMenu()
    {
        creditsPanel.SetActive(false);
        gamePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // Começar o jogo
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
