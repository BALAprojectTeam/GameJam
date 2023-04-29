using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/FoodData")]
public class FoodData : ScriptableObject
{
    public List<FoodComponent> componentList;
    public List<string> tastes;
}
