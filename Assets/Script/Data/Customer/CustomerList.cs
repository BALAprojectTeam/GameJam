using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CustomerList")]
public class CustomerList : ScriptableObject
{
    public List<CustomerData> customerDatas;
}
