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
    public Image visionImage;
    public List<Sprite> visionImages;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateData(FoodData data)
    {
        dish = data;

        //foreignObjectImage.sprite = dish.ForeignObjectImage;

        if (data.visionType == VisionType.None)
        {
            var color = visionImage.color;
            color.a = 0;
            visionImage.color = color;
        }
        else
        {
            var color = visionImage.color;
            color.a = 1;
            visionImage.color = color;
            if (data.visionType == VisionType.Garlic)
            {
                visionImage.sprite = visionImages[0];
            }else if(data.visionType == VisionType.Ginger)
            {
                visionImage.sprite = visionImages[1];
            }
            else if(data.visionType == VisionType.Onion)
            {
                visionImage.sprite = visionImages[2];
            }
        }
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
            originalImage.sprite = dish.BalaedDishImageWithForeignObjectImage;
        }
        else
        {
            originalImage.sprite = dish.BalaedDishImage ;
        }
        //if (dish.hasForeignObject)
        //{
        //    var color = foreignObjectImage.color;
        //    color.a = 1;
        //    foreignObjectImage.color = color;
        //}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
