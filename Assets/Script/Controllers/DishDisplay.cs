using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishDisplay : MonoBehaviour
{
    public FoodData dish;
    public Image originalImage;
    public Image plateImage;
    public Image foreignObjectImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateData(FoodData data)
    {
        dish = data;
        
        foreignObjectImage.sprite = dish.ForeignObjectImage;
        var color = foreignObjectImage.color;
        color.a = 0;
        foreignObjectImage.color = color;
        if (data.hasForeignObject)
        {
            originalImage.sprite = dish.DishesWithForgeinObjectImage;
        }
        else
        {
            originalImage.sprite = dish.PerfectImage;
        }
    }
    public void Bala()
    {
        originalImage.sprite = dish.BalaedDishImage;
        if (dish.hasForeignObject)
        {
            var color = foreignObjectImage.color;
            color.a = 1;
            foreignObjectImage.color = color;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
