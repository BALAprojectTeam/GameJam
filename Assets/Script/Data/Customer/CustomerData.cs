using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/CustomerData")]
public class CustomerData : ScriptableObject
{

    public string templateName = "Human";
    public List<MeatType> dislikeMeatTypes = new List<MeatType>();
    public List<NonMeatType> dislikeNonMeatTypes = new List<NonMeatType>();
    public TasteType dislikeTaste = TasteType.None;
    public VisionType dislikeVisionType = VisionType.None;
    public ExtraComponent preferComponent = ExtraComponent.None;
    public FoodType eatType = FoodType.None;
    public Sprite image;
    public int EatType
    {
        get
        {
            return ((int)eatType);
        }
    }
    public int Dislike
    {
        get
        {
            int dislike = 0;
            foreach (var item in dislikeMeatTypes)
            {
                dislike |= ((int)item);
            }
            foreach (var item in dislikeNonMeatTypes)
            {
                dislike |= ((int)item);
            }
            dislike |= ((int)dislikeTaste);
            dislike |= ((int)dislikeVisionType);
            return dislike;
        }
    }
    public int Prefer
    {
        get
        {
            return ((int)preferComponent);
        }
    }
    public override string ToString()
    {
        string str = templateName + "\n";
        str += "EatType: " + eatType.ToString() + "\n";
        str += "Dislike: \n";
        foreach(var item in dislikeMeatTypes)
        {
            str += item.ToString() + " ";
        }
        foreach (var item in dislikeNonMeatTypes)
        {
            str += item.ToString() + " ";
        }
        str += "\ndislikeTaste: " + dislikeTaste.ToString() + "\n";
        str += "dislikeVision: " + dislikeVisionType.ToString() + "\n";
        str += "Prefer: "+preferComponent.ToString() + "\n";
        return str;
        
    }
}
