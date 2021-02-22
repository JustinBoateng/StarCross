using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStageInfo : MonoBehaviour
{
    public static BattleStageInfo BSI;
    // Start is called before the first frame update


    public  Character[] Chosen = new Character[2];

    public  Stage ChosenStage;

    public void Awake()
    {
        if (BSI == null)
        {
            DontDestroyOnLoad(gameObject);
            BSI = this;
        }

        else if (BSI != null)
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(Character A, Character B, Stage C)
    {
        Chosen[0] = A;
        Chosen[1] = B;
        ChosenStage = C;
    }
}
