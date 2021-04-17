using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuSceneNav : MonoBehaviour
{
    public bool PressToContinue = false;

    public GameObject MenuButtons;
    public GameObject PABNotice;
    public Button FirstSelectedObject;

    // Start is called before the first frame update
    void Start()
    {
        if (PressToContinue == false)
        {
            MenuButtons.gameObject.SetActive(false);
            PABNotice.gameObject.SetActive(true);
        }

        else
        {
                MenuButtons.gameObject.SetActive(true);
                PABNotice.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnGUI()
    {
        if(PressToContinue == false) 
            if (Event.current.isKey) ActivateMenu();
    }

    public void ActivateMenu()
    {
        MenuButtons.gameObject.SetActive(true);
        PABNotice.gameObject.SetActive(false);
        PressToContinue = true;
        EventSystem.current.SetSelectedGameObject(FirstSelectedObject.gameObject);
        EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = "HorizontalA";
        EventSystem.current.GetComponent<StandaloneInputModule>().verticalAxis = "VerticalA";
        EventSystem.current.GetComponent<StandaloneInputModule>().submitButton = "ClashA";
        EventSystem.current.GetComponent<StandaloneInputModule>().cancelButton = "P1Back";

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void ReturntoTitleMenu()
    {
        Debug.Log("Returning to Menu...");
        SceneManager.LoadScene("TitleScene");
    }

    public void ArcadeMode()
    {
        Debug.Log("Going to Single Player...");
        SceneManager.LoadScene("ArcadeSelectScene");
    }

    public void MultiplayerMode()
    {
        Debug.Log("Going to Multiplayer...");
        SceneManager.LoadScene("CharacterSelectScene");
    }

}
