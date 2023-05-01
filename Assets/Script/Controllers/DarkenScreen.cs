using UnityEngine;
using UnityEngine.UI;

public class DarkenScreen : MonoBehaviour
{
    public Image darkMask; // Image 图片
    public float duration; // 整体变暗的过渡时间

    private bool isDark; // 是否已经变暗
    private float targetAlpha; // 目标 alpha 值
    private float currentAlpha; // 当前 alpha 值
    private float originalAlpha;
    private float timer; // 计时器

    private void Start()
    {
        darkMask.color = new Color(0, 0, 0, 0); // 初始化 alpha 值为 0
        isDark = false;
    }

    public void OnClick()
    {
        if (!isDark)
        {
            targetAlpha = 0.5f; // 目标 alpha 值为 0.5
            originalAlpha = 0;
        }
        else
        {
            targetAlpha = 0; // 目标 alpha 值为 0
            originalAlpha = 0.5f;
        }

        timer = 0; // 重置计时器
        isDark = !isDark; // 变暗状态取反
    }

    private void Update()
    {
        if (currentAlpha != targetAlpha)
        {
            timer += Time.deltaTime;

            currentAlpha = Mathf.Lerp(originalAlpha, targetAlpha, timer / duration); // 过渡 alpha 值

            darkMask.color = new Color(0, 0, 0, currentAlpha); // 更新 Image 图片的 alpha 值
        }
    }
}
