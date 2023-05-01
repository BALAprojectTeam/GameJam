using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    public void ShowImage()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
