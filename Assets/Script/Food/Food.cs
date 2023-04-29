using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodData data;
    public readonly HashSet<string> baseTypes = new HashSet<string>();
    public readonly HashSet<string> components = new HashSet<string>();
    public readonly HashSet<string> tastes = new HashSet<string>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in data.componentList)
        {
            baseTypes.Add(item.baseType);
            components.Add(item.name);

        }
        foreach (var item in data.tastes)
        {
            tastes.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
