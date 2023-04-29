using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour, IPointerClickHandler
{
    public int level = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        MainSceneInitInfo.level = level;
        SceneManager.LoadSceneAsync("Scenes/Main", LoadSceneMode.Single);
        
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
