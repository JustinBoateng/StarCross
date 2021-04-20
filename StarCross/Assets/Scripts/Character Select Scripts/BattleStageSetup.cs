using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleStageSetup : MonoBehaviour
{
    public SpriteRenderer Floor;
    public SpriteRenderer Background;
    public SpriteRenderer Alert;

    public GameObject CSMReference;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("CharacterStageManager"))
        {
            CSMReference = GameObject.Find("CharacterStageManager");
            Background.sprite = CSMReference.GetComponent<BattleStageInfo>().ChosenStage.Background.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
