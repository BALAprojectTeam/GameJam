using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FoodData")]
public class FoodData : ScriptableObject
{
    public string foodName;
    public FoodType foodType;
    public List<MeatType> meatComponents;
    public List<NonMeatType> nonMeatComponents;
    public List<ExtraComponent> extraComponents;
    public bool hasForeignObject;
    public VisionType visionType;
    public TasteType tasteType;
}
