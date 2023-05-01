using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  static int levelTime = 500;
    public  static int levelScore = 0;
    public int maxTime ;
    public int needScore ;

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

    public List<TMPro.TextMeshProUGUI> customerInfos;
    public List<Image> chats;
    private Image displayChat = null;
    // tmp info
    public TMPro.TextMeshProUGUI foodInfo;
    public TMPro.TextMeshProUGUI customerInfo;
    public TMPro.TextMeshProUGUI balaTimesText;
    public TMPro.TextMeshProUGUI findText;
    public int balaTimes = 0;
    public bool find = false;

    public List<Sprite> chiefFaces;
    public Image chiefFace;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = levelTime;
        needScore = levelScore;
        foreach (var item in chats)
        {
            var color = item.color;
            color.a = 0;
            item.color = color;
        }
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
        if((needScore <= score))
        {
            FinalManager.finalScore = score;
            SceneManager.LoadScene("WinEndScences");
        }
        else
        {
            FinalManager.finalScore = score;
            SceneManager.LoadScene("FailEndScences");
        }
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
        scoreInfo.text = string.Format("{0}{1:0000}",score>=0?'+':'-', System.Math.Abs(score));
    }

    void NextTurn()
    {
        foreach (var item in chats)
        {
            var color = item.color;
            color.a = 0;
            item.color = color;
        }
        foodManager.GenerateFoodRandom();
        customerManager.GenerateCustomer();

        DishDisplay dish = handManager.leftHand.dish.GetComponent<DishDisplay>();
        dish.UpdateData(foodManager.CurrentFood);

        //foodInfo.text = foodManager.CurrentFood.ToString();
        //customerInfo.text = customerManager.CurrentCustomer.ToString();
        UpdateCustomerInfo();
        balaTimes = 0;
        find = false;

        chiefFace.sprite = chiefFaces[0];
    }
    void UpdateCustomerInfo()
    {
        for(int i = 0; i < customerInfos.Count; ++i)
        {
            customerInfos[i].text = "";
        }
        var customner = customerManager.CurrentCustomer;
        int index = 0;
        if(customner.templateName != "")
        {
            customerInfos[index].text = string.Format("{0}", customner.templateName);
            ++index;
        }
        if(customner.dislikeVisionType != VisionType.None)
        {
            customerInfos[index].text = string.Format("Don't like {0}", customner.dislikeVisionType.ToString());
            ++index;
        }
        if(customner.dislikeTaste != TasteType.None)
        {
            customerInfos[index].text = string.Format("Don't like {0}", customner.dislikeTaste.ToString());
            ++index;
        }
        if (customner.preferComponent != ExtraComponent.None)
        {
            customerInfos[index].text = string.Format("Better have {0}", customner.preferComponent.ToString());
        }
    }
    void ResetTimer()
    {
        lastTime = maxTime;
        remainTime = maxTime;
        isPause = true;
    }
    public void StartTimer()
    {
        isPause = false;
        handManager.Pause(isPause);
    }
    public void PauseTimer()
    {
        isPause = true;
        handManager.Pause(isPause);
    }
    public void Reflush()
    {
        if (foodManager.CurrentFood != null && handManager.HandIdle)
        {
            foodManager.Clear();
            handManager.Remake();
        }
    }
    void DetermindWorldLine(bool isDelivery)
    {
        var tmp = scoreManager.GetFoodScore(foodManager.CurrentFood, customerManager.CurrentCustomer, balaTimes, find, isDelivery);
        score += tmp;
        if (tmp > 0)
        {
            chiefFace.sprite = chiefFaces[1];
        }
        else
        {
            chiefFace.sprite = chiefFaces[2];
        }
        UpdateScore();
        foodManager.Clear();
    }
    public void Bala()
    {
        ++balaTimes;
        //balaTimesText.text = balaTimes.ToString();
        handManager.leftHand.dish.GetComponent<DishDisplay>().Bala();
        if (foodManager.CurrentFood.hasForeignObject)
        {
            find = true;
        }
    }
    public void Find()
    {
        find = !find;
        //findText.text = find.ToString();
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

    public void Eat()
    {
        if (foodManager.CurrentFood != null && handManager.HandIdle)
        {
            switch (foodManager.CurrentFood.tasteType)
            {
                case TasteType.None:
                    displayChat = chats[0];
                    break;
                case TasteType.Salt:
                    displayChat = chats[1];
                    break;
                case TasteType.Sugar:
                    displayChat = chats[2];
                    break;
                case TasteType.Vinegar:
                    displayChat = chats[3];
                    break;
            }
            var color = displayChat.color;
            color.a = 1;
            displayChat.color = color;
        }
    }
}
