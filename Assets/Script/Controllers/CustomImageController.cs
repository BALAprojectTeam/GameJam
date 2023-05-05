using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomImageController : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    public GameManager manager;
    bool canChange = true;
    private void Start()
    {
        // 在游戏开始时随机设置图像
        int randomIndex = Random.Range(0, sprites.Length);
        image.sprite = sprites[randomIndex];
    }
    private void Update()
    {
        if (manager.Idle())
        {
            canChange = true;
        }
    }
    public void OnButtonClick()
    {
        // 当按钮被点击时，重新生成随机图像
    }
    public void Change()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        image.sprite = sprites[randomIndex];
    }
}

