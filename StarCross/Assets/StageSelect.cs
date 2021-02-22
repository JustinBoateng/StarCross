using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelect : MonoBehaviour
{
    public Button[] StageList = new Button[12];
    public Image StageDisplay;
    public Stage[] StageInfo = new Stage[12];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StageDisplay.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;
    }
}
