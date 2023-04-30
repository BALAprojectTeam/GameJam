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
    public List<string> componentDescriptions;

    public int MainComponents
    {
        get
        {
            int ret = 0;
            foreach(var item in meatComponents)
            {
                ret |= ((int)item);
            }
            foreach (var item in nonMeatComponents)
            {
                ret |= ((int)item);
            }
            ret |= ((int)visionType);
            ret |= ((int)tasteType);
            return ret;
        }
    }
    public int ExtraComponents
    {
        get
        {
            int ret = 0;
            foreach(var item in extraComponents)
            {
                ret |= ((int)item);
            }
            return ret;
        }
    }
    public int MainType
    {
        get
        {
            return ((int)foodType);
        }
    }
}
