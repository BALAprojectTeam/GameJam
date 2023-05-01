using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomImageController : MonoBehaviour
{
    public Image image;
    public string CustomImage;
    private Sprite[] images;

    public void OnClick()
    {
        images = Resources.LoadAll<Sprite>(CustomImage);
        image.sprite = images[Random.Range(0, 4)];
    }
}

