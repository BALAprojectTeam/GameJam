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
    public Sprite originalImage;
    public Sprite brokenImage;

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
    public override string ToString()
    {
        string str = foodName + "\n";
        str += "Has Foreign Object? " + hasForeignObject + "\n";
        str += "FoodType: " + foodType.ToString() + "\n";
        str += "Component: \n";
        foreach (var item in meatComponents)
        {
            str += item.ToString() + " ";
        }
        foreach (var item in nonMeatComponents)
        {
            str += item.ToString() + " ";
        }
        str += "\nTaste: " + tasteType.ToString() + "\n";
        str += "Vision: " + visionType.ToString() + "\n";
        str += "Extra: "  + "\n";
        foreach (var item in extraComponents)
        {
            str += item.ToString() + " ";
        }
        return str;

    }
}
