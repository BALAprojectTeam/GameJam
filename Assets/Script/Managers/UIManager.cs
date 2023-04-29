using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(int level)
    {
        UIManager.level = level;
        SceneManager.LoadSceneAsync("Scenes/Main", LoadSceneMode.Single);
    }

    public void NormalSceneEntry(string scene)
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
