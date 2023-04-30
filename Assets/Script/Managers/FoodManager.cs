using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public FoodList totalFoodList;
    private readonly Dictionary<string, FoodData> totalFoodMap = new Dictionary<string, FoodData>();

    private readonly List<FoodData> foodInTable = new List<FoodData>();
    private FoodData currentFood = null;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var item in totalFoodList.foodDatas)
        {
            totalFoodMap.Add(item.foodName, item);
        }
        //for(int i = 0; i < 10; ++i)
        //{
        //    GenerateFoodRandom();
        //}
        //for (int i = 0; i < 10; ++i)
        //{
        //    Debug.LogFormat("{0} {1} {2} {3}", foodInTable[i].foodName, foodInTable[i].hasForeignObject, foodInTable[i].visionType, foodInTable[i].tasteType);
        //}

        foreach(var item in totalFoodList.foodDatas)
        {
            string str = "";
            str += item.name + "\nType: " + item.foodType.ToString() + "\n";
            foreach(var component in item.meatComponents)
            {
                str += "Meat: " + component.ToString() + "\n";
            }
            foreach (var component in item.nonMeatComponents)
            {
                str += "NonMeat: " + component.ToString() + "\n";
            }
            foreach (var component in item.extraComponents)
            {
                str += "Extra: " + component.ToString() + "\n";
            }
            Debug.Log(str);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateFoodRandom()
    {
        int index = Random.Range(0, totalFoodList.foodDatas.Count);
        GenerateFood(index);
    }
    void GenerateFood(int index)
    {
        GenerateFood(totalFoodList.foodDatas[index]);
    }
    void GenerateFood(string name)
    {
        GenerateFood(totalFoodMap[name]);
    }
    void GenerateFood(FoodData data)
    {
        FoodData food = Instantiate(data);
        food.hasForeignObject = RandomForeignObject();
        food.visionType = RandomVisionType();
        food.tasteType = RandomTasteType();

        foodInTable.Add(food);
        if (currentFood == null)
        {
            currentFood = foodInTable[0];
        }
    }

    bool RandomForeignObject()
    {
        return Random.Range(0.0f, 1.0f) > 0.5;
    }
    TasteType RandomTasteType()
    {
        float r = Random.Range(0.0f, 1.0f);
        if (r < 0.25)
        {
            return TasteType.None;
        }
        else if (r < 0.5)
        {
            return TasteType.Sugar;
        }
        else if (r < 0.75)
        {
            return TasteType.Salt;
        }
        else
        {
            return TasteType.Vinegar;
        }
    }
    VisionType RandomVisionType()
    {
        float r = Random.Range(0.0f, 1.0f);
        if (r < 0.25)
        {
            return VisionType.None;
        }else if (r < 0.5)
        {
            return VisionType.Onion;
        }else if (r < 0.75)
        {
            return VisionType.Ginger;
        }
        else
        {
            return VisionType.Garlic;
        }
    }
}
