using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNavigator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rematch()
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ReturntoChar()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }
}
