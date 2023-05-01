using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public HandController leftHand, rightHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause(bool isPause)
    {
        leftHand.isPause = isPause;
        rightHand.isPause = isPause;
    }
    public bool HandIdle
    {
        get
        {
            return leftHand.status == HandController.Status.Wait && rightHand.status == HandController.Status.Wait;
        }
    }
    public void Delivery()
    {
        var tmp = rightHand.dish;
        rightHand.dish = leftHand.dish;
        Vector3 position = tmp.GetComponent<RectTransform>().localPosition;
        position.x = leftHand.DishOriPosx;
        tmp.GetComponent<RectTransform>().localPosition = position;
        leftHand.dish = tmp;
        rightHand.RecciveDish();
    }
    public void PassNewFood()
    {
        leftHand.PassDish();
    }
    public void Remake()
    {
        leftHand.RecciveDish();
    }
}
