using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelPage : MonoBehaviour
{
    public int butoonNumerPerRow = 5;
    public int buttonNumberPerCol = 5;
    public int levelNum = 15;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Debug.Log(rectTransform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
