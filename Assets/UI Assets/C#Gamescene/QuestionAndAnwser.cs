using UnityEngine;
using UnityEngine.SceneManagement;


public class QuestionAndAnwser : MonoBehaviour   //Role页面的返回主页面按钮
{
    public void Return(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}