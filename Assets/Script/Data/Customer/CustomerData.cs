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
}
