using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class NoramlSceneEnter : MonoBehaviour, IPointerClickHandler
{
    public string scenePath;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);

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
