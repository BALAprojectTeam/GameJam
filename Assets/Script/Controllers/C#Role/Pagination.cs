using UnityEngine;
using UnityEngine.UI;

public class Pagination : MonoBehaviour
{
    public Button prevButton;
    public Button nextButton;
    public GameObject[] pages;
    public int currentPage = 0;

    public void Start()
    {
        ShowPage(currentPage); // 显示当前页
        prevButton.onClick.AddListener(PrevPage); // 绑定上一页按钮事件
        nextButton.onClick.AddListener(NextPage); // 绑定下一页按钮事件
    }

    public void PrevPage()
    {
        currentPage--;
        if (currentPage < 0)
        {
            currentPage = pages.Length - 1;
        }
        ShowPage(currentPage); // 显示上一页
    }

    public void NextPage()
    {
        currentPage++;
        if (currentPage >= pages.Length)
        {
            currentPage = 0;
        }
        ShowPage(currentPage); // 显示下一页
    }

    public void ShowPage(int index)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (i == index)
            {
                pages[i].SetActive(true); // 显示当前页
            }
            else
            {
                pages[i].SetActive(false); // 隐藏其他页
            }
        }
    }
}