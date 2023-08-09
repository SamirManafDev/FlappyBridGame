using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject loosePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text loosePanelScoreText;
    [SerializeField] private TMP_Text loosePanelBestScoreText;

    private void Start()
    {
        Time.timeScale = 0;

        PlayerController.Instance.OnScoreUpdate += UpdateScore;
        PlayerController.Instance.OnGameLoose += OpenLoosePanel;
    }

    private void UpdateScore()
    {
        scoreText.text = PlayerController.Instance.Score.ToString();
    }

    private void OpenLoosePanel()
    {
        loosePanelScoreText.text = PlayerController.Instance.Score.ToString();
        loosePanelBestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        loosePanel.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}