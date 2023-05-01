using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FoodHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public void OnPointerEnter(PointerEventData eventData)
    {
        var color = image.color;
        color.a = 1;
        image.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var color = image.color;
        color.a = 0;
        image.color = color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
