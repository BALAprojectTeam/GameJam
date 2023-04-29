using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/FoodList")]
public class FoodList : ScriptableObject
{
    public List<FoodData> foodDatas;
}
