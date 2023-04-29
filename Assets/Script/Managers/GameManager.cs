using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxTime = 10;
    private int lastTime = 10;
    private float remainTime = 10;
    public bool isPause = true;
    public TMPro.TextMeshProUGUI countDownInfo;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDisplayInfo();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
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
                UpdateDisplayInfo();
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
    }
    void UpdateDisplayInfo()
    {
        countDownInfo.text = lastTime.ToString();
    }
    void ResetTimer()
    {
        lastTime = maxTime;
        remainTime = maxTime;
        isPause = false;
    }
    void StartTimer()
    {
        isPause = true;
    }
    void PauseTimer()
    {
        isPause = false;
    }
}
