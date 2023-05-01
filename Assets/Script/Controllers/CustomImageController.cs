using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomImageController : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;

    private void Start()
    {
        // 在游戏开始时随机设置图像
        int randomIndex = Random.Range(0, sprites.Length);
        image.sprite = sprites[randomIndex];
    }

    public void OnButtonClick()
    {
        // 当按钮被点击时，重新生成随机图像
        int randomIndex = Random.Range(0, sprites.Length);
        image.sprite = sprites[randomIndex];
    }
}

