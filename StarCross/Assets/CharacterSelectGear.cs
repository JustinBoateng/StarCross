using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectGear : MonoBehaviour
{
    public Image CharDisplay; //the big panel to display the current selected character
    public Image[] CharNav; //the buttons to show the characters cycling
    public Character[] CurrChars = new Character[5];
    public int InitialCharacterChoice;
    public int PlayerNumber; //indicates which player this script is associated with
    public MasterCharSelect MCSRef;

    public bool HeldLeft = false;
    public bool HeldRight = false;

    public string AxisUsed;
    public int TempNum;
    //Plan: whoever is in slot 2, display their icon to the CharDisplay.
    //Pressing -> or <- triggers the DisplayUpdate function which...
    /*
        1- Checks the list of characters in the MCS.CharListArray
        2- Update each visual of each button with respect to MCS.CharListTracker[i] using MasterCharSelect.MCS.CharListArray.Length to take into account looping
               0                  1                 2                 3                      4
    (i-2)% MCS.CLA.Len.  (i-1)% MCS.CLA.Len         i         (i+1)% MCS.CLA.Len.  (i+2)% MCS.CLA.Len.
        
        3- Update the CharDisplay (The big screen) with the Character in Button 2
    */


    // Start is called before the first frame update
    void Start()
    {
        MCSRef = MasterCharSelect.MCS;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(AxisUsed) < 0 && HeldLeft == false)
        {
            DisplayUpdate("Left");
            HeldLeft = true;
        }
        else if (Input.GetAxis(AxisUsed) > 0 && HeldRight == false)
        {
            DisplayUpdate("Right");
            HeldRight = true;
        }
        else if (Input.GetAxis(AxisUsed) == 0)
        {
            HeldLeft = false;
            HeldRight = false;
        }
    }

    public void DisplayUpdate(string Direction)
    {
        switch (Direction)
        {
            case "Left":
                if ((MCSRef.CharListTracker[PlayerNumber]-1) < 0) MCSRef.CharListTracker[PlayerNumber] = MCSRef.CharListArray.Length-1;
                else MCSRef.CharListTracker[PlayerNumber]--;
                break;

            case "Right":
                if ((MCSRef.CharListTracker[PlayerNumber]+1) > MCSRef.CharListArray.Length-1) MCSRef.CharListTracker[PlayerNumber] = 0;
                else MCSRef.CharListTracker[PlayerNumber]++;
                break;

            case "Initialize":

                break;
        }

        TempNum = MCSRef.CharListTracker[PlayerNumber]; 

        //Debug.Log("Size of MCS.CLA is: " + MasterCharSelect.MCS.CharListArray.Length);
        //Debug.Log("TempNum is " + TempNum);

        CurrChars[2] = MCSRef.CharListArray[TempNum];
        CurrChars[3] = MCSRef.CharListArray[(TempNum + 1) % MCSRef.CharListArray.Length];
        CurrChars[4] = MCSRef.CharListArray[(TempNum + 2) % MCSRef.CharListArray.Length];

        /*
        if ((TempNum - 1) < 0)
        {
            CurrChars[1] = MCSRef.CharListArray[(TempNum - 1) + MCSRef.CharListArray.Length];
        }
        else CurrChars[1] = MCSRef.CharListArray[(TempNum - 1) % MCSRef.CharListArray.Length];


        if ((TempNum - 2) < 0)
        {
            CurrChars[0] = MCSRef.CharListArray[(TempNum - 2) + MCSRef.CharListArray.Length];
        }

        else CurrChars[0] = MCSRef.CharListArray[(TempNum - 2) % MCSRef.CharListArray.Length];
        */
        
        if (TempNum < 2)
        {
            CurrChars[1] = MCSRef.CharListArray[(TempNum - 1) + MCSRef.CharListArray.Length-1];
            CurrChars[0] = MCSRef.CharListArray[(TempNum - 2) + MCSRef.CharListArray.Length-1];
        }

        else
        {
            CurrChars[1] = MCSRef.CharListArray[(TempNum - 1) % MCSRef.CharListArray.Length];
            CurrChars[0] = MCSRef.CharListArray[(TempNum - 2) % MCSRef.CharListArray.Length];
        }
        

        for (int b = 0; b < CharNav.Length; b++)
        {
            CharNav[b].sprite = CurrChars[b].MiniIcon;
        }

        CharDisplay.sprite = CurrChars[2].Icon;

    }


}
