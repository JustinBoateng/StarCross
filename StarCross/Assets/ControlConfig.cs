using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlConfig : MonoBehaviour
{
    public Transform ButtonConfig;
    public Transform buttonPressIndicator;

    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;

    // Start is called before the first frame update
    void Start()
    {
        waitingForKey = false;
        buttonPressIndicator.gameObject.SetActive(false);
        //initialize the current button text to the config
        for (int i = 0; i < ButtonConfig.transform.childCount; i++)
        {

            /*
            if (ButtonConfig.GetChild(i).name == "slashKey")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.slash.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key",""));
                });

            }
            */

            if (ButtonConfig.GetChild(i).name == "LKeyOne")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.LModeOne.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "LKeyTwo")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.LModeTwo.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "RKeyOne")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.RModeOne.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "RKeyTwo")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.RModeTwo.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "AKeyOne")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.AButtonOne.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "AKeyTwo")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.AButtonTwo.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);
                });

            }

            if (ButtonConfig.GetChild(i).name == "BKeyOne")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.BButtonOne.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "BKeyTwo")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.BButtonTwo.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "CKeyOne")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.CButtonOne.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "CKeyTwo")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.CButtonTwo.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "DKeyOne")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.DButtonOne.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }

            if (ButtonConfig.GetChild(i).name == "DKeyTwo")
            {
                ButtonConfig.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.DButtonTwo.ToString();

                GameObject Reference = ButtonConfig.GetChild(i).gameObject;
                //a future reference to the actual button we're talking about

                ButtonConfig.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {

                    SentText(Reference.GetComponentInChildren<Text>());

                    EventSystem.current.SetSelectedGameObject(null);

                    StartAssignment(Reference.name.Replace("Key", ""));

                    EventSystem.current.SetSelectedGameObject(Reference);

                });

            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGUI()
    {
        keyEvent = Event.current; //keyEvent will gain Event.Current (the event that is currently happening in the GUI during that frame)
        if (keyEvent.isKey && waitingForKey && !Input.GetKey(KeyCode.Return) && !Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyUp(KeyCode.Return)) //if there is a keyboard input and we are currently waiting for a key
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }

    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SentText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log("In WaitForKey() waiting for an input");

        yield return new WaitWhile(() => !keyEvent.isKey || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyUp(KeyCode.Return));

        Debug.Log("Input was: " + newKey.ToString());

    }

    public IEnumerator AssignKey(string keyName)
    {
        Debug.Log("set up waitingForKey");
        waitingForKey = true;

        //pop up a screen to tell the player to press a button

        Debug.Log("The panel is open");
        buttonPressIndicator.gameObject.SetActive(true);

        //new WaitForSecondsRealtime(1);
        Debug.Log("we're running WaitForKey to wait for input");
        yield return WaitForKey();

        Debug.Log("Input received, setting up buttons");
        buttonPressIndicator.gameObject.SetActive(false);
        //remove the screen telling the player to press a button

        switch (keyName)
        {
            /*
            case "left":
                GameManager.GM.left = newKey;
                buttonText.text = GameManager.GM.left.ToString();
                PlayerPrefs.SetString("leftKey", GameManager.GM.left.ToString());
                break;

            case "right":
                GameManager.GM.right = newKey;
                buttonText.text = GameManager.GM.right.ToString();
                PlayerPrefs.SetString("rightKey", GameManager.GM.right.ToString());
                break;

            case "up":
                GameManager.GM.up = newKey;
                buttonText.text = GameManager.GM.up.ToString();
                PlayerPrefs.SetString("upKey", GameManager.GM.up.ToString());
                break;

            case "down":
                GameManager.GM.down = newKey;
                buttonText.text = GameManager.GM.down.ToString();
                PlayerPrefs.SetString("downKey", GameManager.GM.down.ToString());
                break;

            case "jump":
                GameManager.GM.jump = newKey;
                buttonText.text = GameManager.GM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", GameManager.GM.jump.ToString());
                break;

            case "slash":
                GameManager.GM.slash = newKey;
                buttonText.text = GameManager.GM.slash.ToString();
                PlayerPrefs.SetString("slashKey", GameManager.GM.slash.ToString());
                break;
                */

            case "LOne":
                GameManager.GM.LModeOne = newKey;
                buttonText.text = GameManager.GM.LModeOne.ToString();
                PlayerPrefs.SetString("LModeOne", GameManager.GM.LModeOne.ToString());
                break;

            case "LTwo":
                GameManager.GM.LModeTwo = newKey;
                buttonText.text = GameManager.GM.LModeTwo.ToString();
                PlayerPrefs.SetString("LModeTwo", GameManager.GM.LModeTwo.ToString());
                break;

            case "ROne":
                GameManager.GM.RModeOne = newKey;
                buttonText.text = GameManager.GM.RModeOne.ToString();
                PlayerPrefs.SetString("RModeOne", GameManager.GM.RModeOne.ToString());
                break;

            case "RTwo":
                GameManager.GM.RModeTwo = newKey;
                buttonText.text = GameManager.GM.RModeTwo.ToString();
                PlayerPrefs.SetString("RModeTwo", GameManager.GM.RModeTwo.ToString());
                break;

            case "AOne":
                GameManager.GM.AButtonOne = newKey;
                buttonText.text = GameManager.GM.AButtonOne.ToString();
                PlayerPrefs.SetString("AButtonOne", GameManager.GM.AButtonOne.ToString());
                break;

            case "ATwo":
                GameManager.GM.AButtonTwo = newKey;
                buttonText.text = GameManager.GM.AButtonTwo.ToString();
                PlayerPrefs.SetString("AButtonTwo", GameManager.GM.AButtonTwo.ToString());
                break;

            case "BOne":
                GameManager.GM.BButtonOne = newKey;
                buttonText.text = GameManager.GM.BButtonOne.ToString();
                PlayerPrefs.SetString("BButtonOne", GameManager.GM.BButtonOne.ToString());
                break;

            case "BTwo":
                GameManager.GM.BButtonTwo = newKey;
                buttonText.text = GameManager.GM.BButtonTwo.ToString();
                PlayerPrefs.SetString("BButtonTwo", GameManager.GM.BButtonTwo.ToString());
                break;

            case "COne":
                
                    GameManager.GM.CButtonOne = newKey;
                    buttonText.text = GameManager.GM.CButtonOne.ToString();
                    PlayerPrefs.SetString("CButtonOne", GameManager.GM.CButtonOne.ToString());
                    break;
                

            case "CTwo":
                GameManager.GM.CButtonTwo = newKey;
                buttonText.text = GameManager.GM.CButtonTwo.ToString();
                PlayerPrefs.SetString("CButtonTwo", GameManager.GM.CButtonTwo.ToString());
                break;

            case "DOne":
                GameManager.GM.DButtonOne = newKey;
                buttonText.text = GameManager.GM.DButtonOne.ToString();
                PlayerPrefs.SetString("DButtonOne", GameManager.GM.DButtonOne.ToString());
                break;

            case "DTwo":
                GameManager.GM.DButtonTwo = newKey;
                buttonText.text = GameManager.GM.DButtonTwo.ToString();
                PlayerPrefs.SetString("DButtonTwo", GameManager.GM.DButtonTwo.ToString());
                break;
        }
        yield return null;
    }



}
