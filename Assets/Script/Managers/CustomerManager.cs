using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public CustomerList customerTemplatesByTypes;
    public CustomerList customerTemplatesByComponents;

    public CustomerData CurrentCustomer { get { return currentCustomer; } }
    CustomerData currentCustomer = null;
    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < 100; ++i)
        //{
        //    int dislike = 0;
        //    currentCustomer = GenerateCustomer();
        //    foreach(var item in currentCustomer.dislikeMeatTypes)
        //    {
        //        dislike |= ((int)item);
        //    }
        //    foreach (var item in currentCustomer.dislikeNonMeatTypes)
        //    {
        //        dislike |= ((int)item);
        //    }
        //    dislike |= ((int)currentCustomer.dislikeTaste);
        //    dislike |= ((int)currentCustomer.dislikeVisionType);
        //    Debug.Log(System.Convert.ToString(dislike, 2));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CustomerData GenerateCustomer()
    {
        CustomerData data = RandomCustomerTemplate();
        data.dislikeTaste = RandomTasteType();
        data.dislikeVisionType = RandomVisionType();
        data.preferComponent = RandomExtraComponent();
        currentCustomer = data;
        return data;
    }
    CustomerData RandomCustomerTemplate()
    {
        float r = Random.Range(0.0f, 1.0f);
        if (r < 0.6)
        {
            return ScriptableObject.CreateInstance<CustomerData>();
        }else if (r < 0.8)
        {
            int i = Random.Range(0, customerTemplatesByTypes.customerDatas.Count);
            return Instantiate(customerTemplatesByTypes.customerDatas[i]);
        }
        else
        {
            int i = Random.Range(0, customerTemplatesByComponents.customerDatas.Count);
            return Instantiate(customerTemplatesByComponents.customerDatas[i]);
        }
    }
    TasteType RandomTasteType()
    {
        float r = Random.Range(0.0f, 1.0f);
        if (r < 0.5)
        {
            return TasteType.None;
        }
        else if (r < 0.5 + 0.5 / 3.0)
        {
            return TasteType.Sugar;
        }
        else if (r < 0.5 + 1.0 / 3.0)
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
        if (r < 0.5)
        {
            return VisionType.None;
        }
        else if (r < 0.5 + 0.5/3.0)
        {
            return VisionType.Onion;
        }
        else if (r < 0.5 + 1.0/3.0)
        {
            return VisionType.GreenOnion;
        }
        else
        {
            return VisionType.Garlic;
        }
    }
    ExtraComponent RandomExtraComponent()
    {
        float noneProbability = 0.75f;
        float extraComponentNum = 4.0f;
        float extraComponentProbability = (1.0f - noneProbability) / extraComponentNum;
        float r = Random.Range(0.0f, 1.0f);
        if (r < noneProbability)
        {
            return ExtraComponent.None;
        }
        else if (r < noneProbability + extraComponentProbability)
        {
            return ExtraComponent.Cucumber;
        }
        else if (r < noneProbability + 2 * extraComponentProbability)
        {
            return ExtraComponent.Grain;
        }
        else if (r < noneProbability + 3 * extraComponentProbability)
        {
            return ExtraComponent.Mushroom;
        }
        else
        {
            return ExtraComponent.Tomato;
        }
    }
}
