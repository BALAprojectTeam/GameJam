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
        for(int i = 0; i < 100; ++i)
        {
            int dislike = 0;
            currentCustomer = GenerateCustomer();
            foreach(var item in currentCustomer.dislikeMeatTypes)
            {
                dislike |= ((int)item);
            }
            foreach (var item in currentCustomer.dislikeNonMeatTypes)
            {
                dislike |= ((int)item);
            }
            dislike |= ((int)currentCustomer.dislikeTaste);
            dislike |= ((int)currentCustomer.dislikeVisionType);
            Debug.Log(System.Convert.ToString(dislike, 2));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    CustomerData GenerateCustomer()
    {
        CustomerData data = RandomCustomerTemplate();
        data.dislikeTaste = RandomTasteType();
        data.dislikeVisionType = RandomVisionType();
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
            return VisionType.Ginger;
        }
        else
        {
            return VisionType.Garlic;
        }
    }
}
