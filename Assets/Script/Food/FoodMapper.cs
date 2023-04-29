using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FoodMapper
{

    public static System.Type GetFoodType(string name)
    {
        return System.Type.GetType(name);
    }
}
