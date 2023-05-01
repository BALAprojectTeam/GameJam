using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    public static int finalScore = 0;
    public TMPro.TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = string.Format("{0}{1:0000}", finalScore >= 0 ? '+' : '-', System.Math.Abs(finalScore));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
