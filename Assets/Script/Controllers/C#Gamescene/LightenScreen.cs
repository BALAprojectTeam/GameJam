using UnityEngine;
using UnityEngine.UI;

public class LightenScreen : MonoBehaviour
{
    public Image image;

    public void OnClick()
    {
        // 将图片不透明度逐渐变为 0，持续时间为 1 秒
        image.CrossFadeAlpha(0f, 1f, false);
    }
}