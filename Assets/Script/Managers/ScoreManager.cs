using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsPass()
    {
        return true;
    }
    public int GetFoodScore(FoodData food, CustomerData customer, int balaTimes,bool findForeignObject,  bool isDelivery)
    {
        if (food.hasForeignObject)
        {
            if (isDelivery)
            {
                return findForeignObject ? -2 : -8;
            }
            else
            {
                return findForeignObject ? 4 : 3;
            }
        }

        // 是否满足基本需求
        bool baseFlag = true;
        baseFlag = baseFlag && (food.MainType & customer.EatType) > 0;
        baseFlag = baseFlag && (food.MainComponents & customer.Dislike) == 0;

        // 不满足基本需求
        if (!baseFlag)
        {
            if (isDelivery)
            {
                return balaTimes > 0 ? -5 : -4;
            }
            else
            {
                return 3;
            }
        }

        // 是否满足特殊需求
        baseFlag = (food.ExtraComponents & customer.Prefer) > 0;

        // 不满足特殊需求
        if (!baseFlag)
        {
            if (isDelivery)
            {
                return balaTimes > 0 ? 3 : 4;
            }
            else
            {
                return 0;
            }
        }

        if (isDelivery)
        {
            return balaTimes > 0 ? 5 : 6;
        }
        else
        {
            return 0;
        }
    }
}
