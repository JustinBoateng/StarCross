using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour 
{
    public static GameManager GM;

    public KeyCode jump { get; set;}
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode down { get; set; }
    public KeyCode up { get; set; }
    public KeyCode slash { get; set; }

    public KeyCode LModeOne { get; set; }
    public KeyCode LModeTwo { get; set; }
    public KeyCode RModeOne { get; set; }
    public KeyCode RModeTwo { get; set; }
    public KeyCode AButtonOne { get; set; }
    public KeyCode AButtonTwo { get; set; }
    public KeyCode BButtonOne { get; set; }
    public KeyCode BButtonTwo { get; set; }
    public KeyCode CButtonOne { get; set; }
    public KeyCode CButtonTwo { get; set; }
    public KeyCode DButtonOne { get; set; }
    public KeyCode DButtonTwo { get; set; }

    /*
     depending on if we're getting jump (x = GM.jump)
     or setting it (jump = x)
     we can impose certain rules
     that's the point of these {get;set;} brackets
         */


    private void Awake()
    {
      
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
    
        else if (GM != this)
            Destroy(gameObject);
       

        /*
        jump = (KeyCode) System.Enum.Parse(
                            typeof(KeyCode), 
                            PlayerPrefs.GetString("jumpKey", "Space")
                         );
        //up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        //down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        //left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        //right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

        //slash = (KeyCode)System.Enum.Parse(
                            typeof(KeyCode), //assigns PlayerPrefs.GetString(...) to a "type of keycode"
                            PlayerPrefs.GetString("slashKey", "E") //E is default if nothing is there
                          );
        */

        LModeOne = (KeyCode)System.Enum.Parse(
                            typeof(KeyCode), 
                            PlayerPrefs.GetString("LModeOne", "A") 
                            );
        LModeTwo = (KeyCode)System.Enum.Parse(
                            typeof(KeyCode),
                            PlayerPrefs.GetString("LModeTwo", "J") 
                            );
        RModeOne = (KeyCode)System.Enum.Parse(
                            typeof(KeyCode),
                            PlayerPrefs.GetString("RModeOne", "D")
                           );
        RModeTwo = (KeyCode)System.Enum.Parse(
                            typeof(KeyCode),
                            PlayerPrefs.GetString("RModeTwo", "L")
                            );

        AButtonOne = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("AButtonOne", "Alpha1")
                           );
        AButtonTwo = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("AButtonTwo", "Alpha7")
                           );
        BButtonOne = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("BButtonOne", "Alpha2")
                           );
        BButtonTwo = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("BButtonTwo", "Alpha8")
                           );
        CButtonOne = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("CButtonOne", "Alpha3")
                           );
        CButtonTwo = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("CButtonTwo", "Alpha9")
                           );
        DButtonOne = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("DButtonOne", "Alpha4")
                           );
        DButtonTwo = (KeyCode)System.Enum.Parse(
                           typeof(KeyCode),
                           PlayerPrefs.GetString("DButtonTwo", "Alpha0")
                           );

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
