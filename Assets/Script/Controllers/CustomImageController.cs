using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomImageController : MonoBehaviour
{
    public Image[] images;  // 图片数组

    private void Start()
    {
        // 随机生成一个 0 到 2 之间的整数，用来决定生成哪一个图片
        int randomIndex = Random.Range(0, 4);

        // 根据随机数生成相应的图片
        images[randomIndex].gameObject.SetActive(true);
    }
}

