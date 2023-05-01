using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMPro.TextMeshProUGUI easyScoreText;
    public TMPro.TextMeshProUGUI easyTimeText;
    public int easyScore = 0;
    public int easyTime = 1000;

    public TMPro.TextMeshProUGUI normalScoreText;
    public TMPro.TextMeshProUGUI normalTimeText;
    public int normalScore = 0;
    public int normalTime = 500;

    public TMPro.TextMeshProUGUI hardScoreText;
    public TMPro.TextMeshProUGUI hardTimeText;
    public int hardScore = 0;
    public int hardTime = 100;

    private void Start()
    {

        if (easyScoreText)
        {
            GameManager.levelTime = easyTime;
            GameManager.levelScore = easyScore;
            easyScoreText.text = easyScore.ToString();
            easyTimeText.text = easyTime.ToString() + "s";

            normalScoreText.text = normalScore.ToString();
            normalTimeText.text = normalTime.ToString() + "s";

            hardScoreText.text = hardScore.ToString();
            hardTimeText.text = hardTime.ToString() + "s";
        }

    }
    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Select(int i)
    {
        switch (i)
        {
            case 0:
                GameManager.levelTime = easyTime;
                GameManager.levelScore = easyScore;
                break;
            case 1:
                GameManager.levelTime = normalTime;
                GameManager.levelScore = normalScore;
                break;
            case 2:
                GameManager.levelTime = hardTime;
                GameManager.levelScore = hardScore;
                break;
        }
    }

    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void Role(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}