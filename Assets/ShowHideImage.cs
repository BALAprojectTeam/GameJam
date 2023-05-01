using UnityEngine;

public class ShowHideImage : MonoBehaviour
{
    public GameObject image;

    void Start()
    {
        // 隐藏图片
        image.SetActive(false);
    }

    void Update()
    {
        // 监听鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            // 如果图片被激活了，则隐藏它
            if (image.activeSelf)
            {
                image.SetActive(false);
            }
        }
    }

    public void ShowImage()
    {
        // 显示图片
        image.SetActive(true);
    }
}
