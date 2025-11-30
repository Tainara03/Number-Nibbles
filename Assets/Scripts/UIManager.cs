using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject creditsPanel;
    public CupcakeMathManager cupcakeMathManager;

    public void ShowCredits()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        cupcakeMathManager.ResetGame();
        creditsPanel.SetActive(false);
        gamePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
