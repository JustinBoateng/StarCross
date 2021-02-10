﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCharSelect : MonoBehaviour
{
    public static MasterCharSelect MCS;
    public List<Character> CharList;
    public Character[] CharListArray;
    public int[] CharListTracker; // functions to scroll through the CharList for each player.
    public CharacterSelectGear[] CSGSystem = new CharacterSelectGear[2];

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

       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
