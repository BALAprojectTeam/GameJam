using UnityEngine;
using UnityEngine.UI;

public class ShowButtonsOnClick : MonoBehaviour
{
    public Button[] buttonsToShow;

    void Start()
    {
        foreach (Button button in buttonsToShow)
        {
            button.gameObject.SetActive(false); // 隐藏按钮
        }
    }

    public void ShowButtons()
    {
        foreach (Button button in buttonsToShow)
        {
            button.gameObject.SetActive(true); // 显示按钮
        }
    }
}