using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInfoPass : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Main" + UIManager.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
