using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckTMPText : MonoBehaviour
{
    public TMP_Text tmpText;
    public string trueSceneName;
    public string falseSceneName;

    void Update()
    {
        if (tmpText != null)
        {
            string text = tmpText.text.Trim().ToLower(); // 获取并转换TMP text的内容为小写
            if (text == "true")
            {
                SceneManager.LoadScene(trueSceneName);
            }
            else if (text == "false")
            {
                SceneManager.LoadScene(falseSceneName);
            }
        }
    }
}
