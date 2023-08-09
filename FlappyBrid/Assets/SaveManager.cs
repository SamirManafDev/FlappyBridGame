using UnityEngine;

public class SaveManager : MonoBehaviour
{
    void Start()
    {
        PlayerController.Instance.OnScoreUpdate += OnScoreUpdate;

        Application.quitting += ApplicationOnQuitting;
    }

    private void ApplicationOnQuitting()
    {
        PlayerPrefs.Save();
    }

    private void OnScoreUpdate()
    {
        if (PlayerPrefs.GetInt("BestScore") < PlayerController.Instance.Score)
        {
            PlayerPrefs.SetInt("BestScore", PlayerController.Instance.Score);
        }
    }
}