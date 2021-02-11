using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Linq.Enumerable;


public class CharacterSelectGear : MonoBehaviour
{
    public Image CharDisplay; //the big panel to display the current selected character
    public Image[] CharNav; //the buttons to show the characters cycling
    public Character[] CurrChars = new Character[5];
    public int InitialCharacterChoice;
    public int PlayerNumber; //indicates which player this script is associated with
    public MasterCharSelect MCSRef;

    

    //use these strings to set up player controllers in Unity
    public string AxisUsed;
    public string PS;
    public string PB;

    public bool HeldLeft = false;
    public bool HeldRight = false;
    public bool HeldPS = false;
    public bool HeldPB = false;

    public Text CharName;
    //Plan: whoever is in slot 2, display their icon to the CharDisplay.
    //Pressing -> or <- triggers the DisplayUpdate function which...
    /*
        1- Checks the list of characters in the MCS.CharListArray
        2- Update each visual of each button with respect to MCS.CharListTracker[i] using MasterCharSelect.MCS.CharListArray.Length to take into account looping
               0                  1                 2                 3                      4
    (i-2)% MCS.CLA.Len.  (i-1)% MCS.CLA.Len         i         (i+1)% MCS.CLA.Len.  (i+2)% MCS.CLA.Len.
        
        3- Update the CharDisplay (The big screen) with the Character in Button 2
    */


    //selected units        
    public Image[] ChosenUnitsImages;
    public Character[] ChosenUnits;
    public int MaxPartySize;
    public bool PlayerStandby = false;


    // Start is called before the first frame update
    void Start()
    {
        MCSRef = MasterCharSelect.MCS;
        ChosenUnitsImages.Count();

        ChosenUnits = new Character[MaxPartySize];
        //ChosenUnitsImages = new Image[MaxPartySize];
        //^Set this up in the Unity Editor^
        for (int i = 0; i < ChosenUnitsImages.Length; i++)
        {
            ChosenUnitsImages[i].gameObject.SetActive(false);
        }

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

        if (Input.GetButton(PS) && HeldPS == false)
        {
            SelectCharacter();
            HeldPS = true;
        }

        else if(!Input.GetButton(PS) && HeldPS == true)
        {
            HeldPS = false;
        }

        if (Input.GetButton(PB) && HeldPB == false)
        {
            ChosenUpdateDelete();
            HeldPB = true;
        }

        else if (!Input.GetButton(PB) && HeldPB == true)
        {
            HeldPB = false;
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

        int TempNum = MCSRef.CharListTracker[PlayerNumber]; 

        //Debug.Log("Size of MCS.CLA is: " + MasterCharSelect.MCS.CharListArray.Length);
        //Debug.Log("TempNum is " + TempNum);

        CurrChars[2] = MCSRef.CharListArray[TempNum];
        CurrChars[3] = MCSRef.CharListArray[(TempNum + 1) % MCSRef.CharListArray.Length];
        CurrChars[4] = MCSRef.CharListArray[(TempNum + 2) % MCSRef.CharListArray.Length];

        
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
        
        
        /*
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
        */

        for (int b = 0; b < CharNav.Length; b++)
        {
            CharNav[b].sprite = CurrChars[b].MiniIcon;
        }

        CharDisplay.sprite = CurrChars[2].Icon;
        CharName.text = CurrChars[2].Name;

    }

    public void SelectCharacter()
    {
        //0- Check to see if the character already exists in the array
        //1- Assign who is in slot 2 to ChosenUnits[ChosenUnits.Count()]  <--This should assign the unit to the appropriate slot
        //2- update the ChosenUnitsImages
        //3- check to see if the MaxpartySize has been reached. If so, call MCS and run Ready with this Player's Number

        //-0
        if (ChosenUnits.Contains(CurrChars[2]))
        {
            Debug.Log("Character already Selected");
            return;
        }

        if (ChosenUnits.Count(s => s != null) >= MaxPartySize)
        {
            Debug.Log("Character Selection Full");
            return;
        }
        //-1
        Debug.Log("CU.C size is " + ChosenUnits.Count(s => s != null));
        ChosenUnits[ChosenUnits.Count(s => s != null)] = CurrChars[2];

        //-2
        Debug.Log("CUI.C size is " + ChosenUnitsImages.Count(s => s.gameObject.activeSelf == true));
        ChosenUnitsImages[ChosenUnitsImages.Count(s => s.gameObject.activeSelf == true)].gameObject.SetActive(true);//set the image to be active
        ChosenUnitsImages[ChosenUnitsImages.Count(s => s.gameObject.activeSelf == true)-1].sprite = ChosenUnits[ChosenUnits.Count(s => s != null) - 1].Icon;

        //-3
        if (ChosenUnits.Count(s => s != null) >= MaxPartySize)
        {
            MasterCharSelect.MCS.Ready(PlayerNumber);
            PlayerStandby = true;
        }
        

    }

    public void ChosenUpdateDelete()
    {
        //1- remove from both ChosenUnits and ChosenUnitsImages the last added unit
        //2- if Chosenunits.Count >= MaxPartySize then call the MCS's Ready Function using this CSG's PlayerNumber as a parameter
        if (ChosenUnits.Count(s => s != null) == 0)
        {
            Debug.Log("No one is Selected");
            return;
        }
        ChosenUnits[ChosenUnits.Count(s => s != null) - 1] = null;
        ChosenUnitsImages[ChosenUnitsImages.Count(s => s.gameObject.activeSelf == true) - 1].sprite = null;
        ChosenUnitsImages[ChosenUnitsImages.Count(s => s.gameObject.activeSelf == true) - 1].gameObject.SetActive(false);

        PlayerStandby = false;
    }
}
