using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/CustomerData")]
public class CustomerData : ScriptableObject
{

    public string templateName = "Human";
    public List<MeatType> dislikeMeatTypes = new List<MeatType>();
    public List<NonMeatType> dislikeNonMeatTypes = new List<NonMeatType>();
    public TasteType dislikeTaste;
    public VisionType dislikeVisionType;
    public ExtraComponent preferComponent;
    public FoodType eatType;
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
}
