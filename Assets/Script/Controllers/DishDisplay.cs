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
        originalImage.sprite = dish.originalImage;
        foreignObjectImage.sprite = dish.brokenImage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
