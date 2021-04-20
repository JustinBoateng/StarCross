using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCodeMechanism : MonoBehaviour
{

    public Button CodeInput;

    public Button[] Inputs;


    // Start is called before the first frame update
    void Awake()
    {
       for(int i = 0; i < Inputs.Length; i++)
        {
            string BText = Inputs[i].GetComponentInChildren<Text>().text;

            if (BText.Contains("<"))
            {
                Inputs[i].onClick.AddListener(delegate
                {
                    if (CodeInput.GetComponentInChildren<Text>().text.Length > 0)
                        CodeInput.GetComponentInChildren<Text>().text = CodeInput.GetComponentInChildren<Text>().text.Remove(CodeInput.GetComponentInChildren<Text>().text.Length - 1);
                });
            }
            //delete a character from the input

            else
            {
                Inputs[i].onClick.AddListener(delegate
                {
                    Debug.Log("You pressed the " + BText + " button");

                       CodeInput.GetComponentInChildren<Text>().text = CodeInput.GetComponentInChildren<Text>().text + BText;
                    
                });
            }//enter the character in the button into the input
        }

        CodeInput.onClick.AddListener(() => CodeCheck(CodeInput.GetComponentInChildren<Text>().text));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CodeCheck(string Code)
    {
        Debug.Log("You Entered the Code: " + Code);
    }

    public void ClearCode()
    {
        CodeInput.GetComponentInChildren<Text>().text = "";
    }
}
