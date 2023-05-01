using UnityEngine;

public class ShowHideImage : MonoBehaviour
{
    public GameObject image;

    void Start()
    {
        // ����ͼƬ
        image.SetActive(false);
    }

    void Update()
    {
        // ����������¼�
        if (Input.GetMouseButtonDown(0))
        {
            // ���ͼƬ�������ˣ���������
            if (image.activeSelf)
            {
                image.SetActive(false);
            }
        }
    }

    public void ShowImage()
    {
        // ��ʾͼƬ
        image.SetActive(true);
    }
}
