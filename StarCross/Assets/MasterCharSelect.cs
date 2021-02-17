using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MasterCharSelect : MonoBehaviour
{
    public static MasterCharSelect MCS;
    public List<Character> CharList;
    public Character[] CharListArray;
    public int[] CharListTracker; // functions to scroll through the CharList for each player.
    public CharacterSelectGear[] CSGSystem = new CharacterSelectGear[2];

    public int[] PlayerStagePriority = new int [2];

    public StageSelect SS;

    private void Awake()
    {
        if (MCS == null)
        {
            DontDestroyOnLoad(gameObject);
            MCS = this;
        }

        else if (MCS != this) { Destroy(gameObject); }
    }

    void Start()
    {


        CharListTracker[0] = 0;
        CharListTracker[1] = 1;
        //CharListTracker[PlayerNumber] = Initialize the position

        CharListArray = CharList.ToArray();
        //Debug.Log("Size of CharListArray is " + CharListArray.Length);
        //because there can be new characters added, we can add it to the CharList.
        //we'll convert the List to the Array for the players to navigate through afterwards.

        PlayerStagePriority[0] = 0;
        PlayerStagePriority[1] = 0;

        SS.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ready(int PN)
    {
        if (PN == 0)
        {
            if (PlayerStagePriority[1] == 0) PlayerStagePriority[0] = 1;
            else
                StageSelectPopup(); //setup the stage selection with Player 2 as the navigator
        }
        else if (PN == 1)
        {
            if (PlayerStagePriority[0] == 0) PlayerStagePriority[1] = 1;
            else StageSelectPopup();
            //setup the stage selection with Player 1 as the navigator
        }

        if (PN == -1)
        {
            PlayerStagePriority[0] = 0;
            PlayerStagePriority[1] = 0;
        }

        if (PN == 10)
        {
            PlayerStagePriority[0] = 0;
        }//reverse the selection for player 1

        if (PN == 11)
        {
            PlayerStagePriority[1] = 0;
        }//reverse the selection for player 2

        //just use Ready(-1) when exiting the StageSelect flag

    }

    public void StageSelectPopup()
    {
        SS.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(SS.StageList[0].gameObject);

        if (PlayerStagePriority[1] == 1)
        {
            EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = CSGSystem[1].AxisUsed;
            EventSystem.current.GetComponent<StandaloneInputModule>().verticalAxis = CSGSystem[1].VAxisUsed;
        }
        else if (PlayerStagePriority[0] == 1)
        {
            EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = CSGSystem[0].AxisUsed;
            EventSystem.current.GetComponent<StandaloneInputModule>().verticalAxis = CSGSystem[0].VAxisUsed;
        }
    }
}
