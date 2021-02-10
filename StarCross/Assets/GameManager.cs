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
       


        jump = (KeyCode) System.Enum.Parse(
                            typeof(KeyCode), 
                            PlayerPrefs.GetString("jumpKey", "Space")
                         );
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

        slash = (KeyCode)System.Enum.Parse(
                            typeof(KeyCode), //assigns PlayerPrefs.GetString(...) to a "type of keycode"
                            PlayerPrefs.GetString("slashKey", "E") //E is default if nothing is there
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
