using UnityEngine;
using UnityEngine.UI;

public class HideButtonsOnClick : MonoBehaviour     //点击 GoOn 按钮
{
    public Button[] buttonsToHide;

    public void HideButtons()
    {
        for (int i = 0; i < buttonsToHide.Length; i++)
        {
            buttonsToHide[i].gameObject.SetActive(false); // 隐藏按钮
        }
    }
}

