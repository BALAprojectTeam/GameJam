using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public enum Status
    {
        Wait,

        MoveForward,
        MoveBackWithDish,

        MoveForwardWithDish,
        MoveBack,
    }
    public Status status = Status.Wait;
    public float processTimes = 10;
    public GameObject dish;

    public float disWithDish;
    public float dishTargetX;
    public float DishOriPosx { get
        {
            return dishOriPosX;
        } }

    public bool isPause = false;

    private float targetX;
    private float handOriPosX;
    private float dishOriPosX;
    private RectTransform handTransform;

    private float DishX
    {
        get
        {
            return dish.GetComponent<RectTransform>().localPosition.x;
        }
        set
        {
            var position = dish.GetComponent<RectTransform>().localPosition;
            position.x = value;
            dish.GetComponent<RectTransform>().localPosition = position;
        }
    }
    private float HandX
    {
        get
        {
            return handTransform.localPosition.x;
        }
        set
        {
            var position = handTransform.localPosition;
            position.x = value;
            handTransform.localPosition = position;
        }
    }
    private float v = 0;
    private bool withDish;
    public void RecciveDish()
    {
        if (status == Status.Wait)
        {
            status = Status.MoveForward;
        }

    }

    public void PassDish()
    {
        if (status == Status.Wait)
        {
            status = Status.MoveForwardWithDish;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        handTransform = gameObject.GetComponent<RectTransform>();
        dishOriPosX = DishX;
        handOriPosX = dishOriPosX + disWithDish;

        //var position = handTransform.position;
        //position.x = handOriPosX;
        //handTransform.position = position;
        HandX = handOriPosX;

        targetX = dishTargetX + disWithDish;
        float s = (targetX - handOriPosX);
        v = Mathf.Abs(2 * s / (processTimes));
        //Debug.Log(targetX);
        //Debug.Log(handOriPosX);

    }
    void SwitchStatus()
    {
        switch (status)
        {
            case Status.MoveForward:
                if (HandX == targetX)
                {
                    status = Status.MoveBackWithDish;
                }
                break;
            case Status.MoveForwardWithDish:
                if(HandX == targetX)
                {
                    status = Status.MoveBack;
                }
                break;
            case Status.MoveBack:
            case Status.MoveBackWithDish:
                if (HandX == handOriPosX)
                {
                    status = Status.Wait;
                }
                break;
            default:
                break;
        }

    }
    void MoveForwad(bool withDish)
    {
        float dir = (targetX - handOriPosX) > 0 ? 1 : -1;
        float s = Time.deltaTime * v * dir;
        if (dir > 0)
        {
            s = Mathf.Min(s, targetX - HandX);
        }
        else
        {
            s = Mathf.Max(s, targetX - HandX);
        }
        HandX += s;
        if (withDish)
        {
            DishX += s;
        }
        //Debug.Log(handTransform.position);
    }
    void MoveBack(bool withDish)
    {
        float dir = (targetX - handOriPosX) > 0 ? -1 : 1;
        float s = Time.deltaTime * v * dir;
        if (dir > 0)
        {
            s = Mathf.Min(s, handOriPosX - HandX);
        }
        else
        {
            s = Mathf.Max(s, handOriPosX - HandX);
        }
        HandX += s;
        if (withDish)
        {
            DishX += s;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPause)
        {
            bool withDish = status == Status.MoveForwardWithDish || status == Status.MoveBackWithDish;

            switch (status)
            {
                case Status.MoveForwardWithDish:
                case Status.MoveForward:
                    MoveForwad(withDish);
                    break;
                case Status.MoveBackWithDish:
                case Status.MoveBack:
                    MoveBack(withDish);
                    break;
                default:
                    break;
            }
            SwitchStatus();
        }

    }
}
