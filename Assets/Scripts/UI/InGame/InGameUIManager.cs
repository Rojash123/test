using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletedPanel;

    [Header("Events SO")]
    [SerializeField] GameEventSO gameEvents;
    private void Awake()
    {
        gameEvents.OnRoundCompleted += GameEvents_OnRoundCompleted;
        gameEvents.OnGameOver += GameEvents_OnGameOver;
    }
    private void OnDestroy()
    {
        gameEvents.OnRoundCompleted -= GameEvents_OnRoundCompleted;
        gameEvents.OnGameOver -= GameEvents_OnGameOver;
    }
    private void GameEvents_OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
    private void GameEvents_OnRoundCompleted()
    {
        levelCompletedPanel.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
