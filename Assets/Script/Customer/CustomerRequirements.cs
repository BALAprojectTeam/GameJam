using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRequirements : MonoBehaviour
{
    public CustomerRequirementData data;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="food"></param>
    /// <returns>
    /// 0代表无偏好
    /// >0代表喜欢
    /// <0代表厌恶
    /// </returns>
    public int GetAttitude(Food food)
    {
        return 0;
    }
    public int GetAttitudeOfComponent(string foodName)
    {
        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
