using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxTime = 1000;
    private int lastTime = 50;
    private float remainTime;
    public bool isPause = true;
    public TMPro.TextMeshProUGUI countDownInfo;

    private int score = 0;
    public TMPro.TextMeshProUGUI scoreInfo;

    FoodManager foodManager;
    ScoreManager scoreManager;
    CustomerManager customerManager;
    HandManager handManager;

    // tmp info
    public TMPro.TextMeshProUGUI foodInfo;
    public TMPro.TextMeshProUGUI customerInfo;
    public TMPro.TextMeshProUGUI balaTimesText;
    public TMPro.TextMeshProUGUI findText;
    public int balaTimes = 0;
    public bool find = false;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        UpdateCountDownInfo();
        UpdateScore();
        foodManager = gameObject.GetComponent<FoodManager>();
        scoreManager = gameObject.GetComponent<ScoreManager>();
        customerManager = gameObject.GetComponent<CustomerManager>();
        handManager = gameObject.GetComponent<HandManager>();
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        if(foodManager.CurrentFood == null && handManager.HandIdle)
        {
            NextTurn();
            handManager.PassNewFood();
        }
    }
    void CountDown()
    {
        if (!isPause)
        {
            remainTime -= Time.deltaTime;
            int nowTime = Mathf.CeilToInt(remainTime);
            if (nowTime != lastTime)
            {
                lastTime = nowTime;
                UpdateCountDownInfo();
            }
            if (remainTime <= 0)
            {
                EndGame();
            }
        }
    }
    void EndGame()
    {
        isPause = true;
        scoreInfo.text = scoreManager.IsPass().ToString();
    }
    void UpdateCountDownInfo()
    {
        //Debug.Log(lastTime);
        int min = lastTime / 60;
        int sec = lastTime % 60;
        countDownInfo.text = string.Format("{0: 00}:{1:00}", min, sec);
    }

    void UpdateScore()
    {
        scoreInfo.text = score.ToString();
    }

    void NextTurn()
    {
        foodManager.GenerateFoodRandom();
        customerManager.GenerateCustomer();

        DishDisplay dish = handManager.leftHand.dish.GetComponent<DishDisplay>();
        dish.UpdateData(foodManager.CurrentFood);

        foodInfo.text = foodManager.CurrentFood.ToString();
        customerInfo.text = customerManager.CurrentCustomer.ToString();
        balaTimes = 0;
        find = false;
    }

    void ResetTimer()
    {
        lastTime = maxTime;
        remainTime = maxTime;
        isPause = true;
    }
    void StartTimer()
    {
        isPause = false;
        handManager.Pause(isPause);
    }
    void PauseTimer()
    {
        isPause = true;
        handManager.Pause(isPause);
    }
    void DetermindWorldLine(bool isDelivery)
    {
        score += scoreManager.GetFoodScore(foodManager.CurrentFood, customerManager.CurrentCustomer, balaTimes, find, isDelivery);
        UpdateScore();
        foodManager.Clear();
    }
    public void Bala()
    {
        ++balaTimes;
        balaTimesText.text = balaTimes.ToString();
    }
    public void Find()
    {
        find = !find;
        findText.text = find.ToString();
    }
    public void Delivery()
    {
        if (foodManager.CurrentFood != null && handManager.HandIdle)
        {
            DetermindWorldLine(true);
            handManager.Delivery();
        }
        
    }
    public void Remake()
    {
        if (foodManager.CurrentFood != null && handManager.HandIdle)
        {
            DetermindWorldLine(false);
            handManager.Remake();
        }
        
    }
}
