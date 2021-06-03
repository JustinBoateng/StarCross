using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GameState : MonoBehaviour
{
    public float timer;

    public GameObject alert;
    public bool MasterFlag = false;

    public SCPlayer PlayerA;
    private float horizontalA;
    public bool PlayerAIsStunned = false;
    public float StunCounterA = 0;
    public bool PlayerAFlagUp = false;
    

    public SCPlayer PlayerB;
    private float horizontalB;
    public bool PlayerBIsStunned = false;
    public float StunCounterB = 0;
    public bool PlayerBFlagUp = false;

    public Transform PAOriginalPosition;
    public Transform PBOriginalPosition;
    public Transform TiePosition;
    public bool RoundOver = false;
    public bool GameOver = false;
    public float ResetTimer = 3;

    public int[] ScoreBoard = new int[2];
    public int Round = 0;
    public int WinCond;
    public int Winner = 0;
    //If P1 wins, Winner = 1. if P2 wins, Winner = 2

    public GameObject Player1WinScreen;
    public GameObject Player2WinScreen;
    public Transform ScorePositionA;
    public Transform ScorePositionB;

    public float[] FinishedTimes;
    public Text[] TimePrints;
    public float CurrentFinishedTime;
    public int RoundCounter = 1;
    public int[] Points = new int[2] {0,0};

    public float TimeLimit;

    public Camera MainCamera;
    public float zoomAMT = 20f;
    public float prevZoomAMT;
    public float prevDistance = 4;
    public Transform CameraPoint;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 0;
        alert.gameObject.SetActive(false);
        PAOriginalPosition.position = PlayerA.transform.position;
        PBOriginalPosition.position = PlayerB.transform.position;
        TiePosition.transform.position = new Vector2((PlayerA.transform.position.x + PlayerB.transform.position.x) / 2, (PlayerA.transform.position.y + PlayerB.transform.position.y) / 2);

        ScoreBoard[0] = 0;
        ScoreBoard[1] = 0;
        Round = 0;

        Player1WinScreen.gameObject.SetActive(false);
        Player2WinScreen.gameObject.SetActive(false);

        FinishedTimes = new float[(WinCond * 2) -1];
        //TimePrints = new Text[FinishedTimes.Length];
        
        RoundCounter = 1;
        GameOver = false;

        //prevZoomAMT = zoomAMT;

    }

    //Start and Awake work in similar ways except that Awake is called first and, unlike Start, will be called even if the script component is disabled.

    // Update is called once per frame
    void Update()
    {
        LocateOpponent();
        //CameraAdjust();
        //MainCamera.fieldOfView = zoomAMT;
        //prevZoomAMT = zoomAMT;


        if (!RoundOver)
        {
            timer += Time.deltaTime;


            //Debug.Log("Counter = " + (int)timer);


            //MasterFlag flips
            if (timer >= TimeLimit)
            {
                alert.gameObject.SetActive(true);
                MasterFlag = true;
                PlayerA.Activate();
                PlayerB.Activate();
            }

            horizontalA = Input.GetAxisRaw("HorizontalA");
            horizontalB = Input.GetAxisRaw("HorizontalB");

            //(Input Check)
            //IF player isn't stunned
            /*
            if (!PlayerAIsStunned)
            {
                //check for lone button input.                
                if (Input.GetButtonDown("ClashA") && horizontalA > -1)
                {
                    //if MasterFlag is down, stall player for 2 seconds
                    if (MasterFlag == false) PlayerAIsStunned = true;

                    //else if MasterFlag is up, Player Flag goes up
                    else PlayerAFlagUp = true;
                }

            }

            if (!PlayerBIsStunned)
            {
                if (Input.GetButtonDown("ClashB") && horizontalB < 1)
                {
                    if (MasterFlag == false) PlayerBIsStunned = true;

                    else PlayerBFlagUp = true;
                }

            }


            //Stun Check
            if (PlayerAIsStunned)
            {
                StunCounterA += Time.deltaTime;

                if (StunCounterA >= 2) //break out of stun
                {
                    PlayerAIsStunned = false;
                    StunCounterA = 0;
                }

            }

            if (PlayerBIsStunned)
            {
                StunCounterB += Time.deltaTime;

                if (StunCounterB >= 2) //break out of stun
                {
                    PlayerBIsStunned = false;
                    StunCounterB = 0;
                }

            }
            

            //flag check (Outcome Check)
            */
            //if PlayerAFlag is up, but PlayerBFlag isnt...
            if (PlayerB.isHit)
            {
                //Play Animation
                Debug.Log("Player 1 Wins. Time: " + timer);
                Points[0]++;
                //PlayerA.transform.position = new Vector2(PBOriginalPosition.transform.position.x + 2, PlayerA.transform.position.y);
                RoundOver = true;
                Round++;

                ScoreBoard[0]++;
            }
            //playerA wins. 
            //point for player A
            
            
            //if PlayerBFlag is up, but PlayerAFlag isnt...
            if (PlayerA.isHit)
            {
                //Play Animation
                Debug.Log("Player 2 Wins. Time: " + timer);
                Points[1]++;
                //PlayerB.transform.position = new Vector2(PAOriginalPosition.transform.position.x - 2, PlayerB.transform.position.y);
                RoundOver = true;
                Round++;
                ScoreBoard[1]++;
            }
            //playerB wins. 
            //point for player B            

            if (PlayerB.isHit && PlayerA.isHit)
            {
                RoundOver = true;
               
                Round--;
                /*
               ScoreBoard[0]++;
               ScoreBoard[1]++;
               */
            }//Players traded blows

            //if both flags are up (Condition A)
            //it's a tie
            /*
            if (PlayerAFlagUp && PlayerBFlagUp)
            {
                //Play Animation
                Debug.Log("It's a draw. Time: " + timer);
                PlayerA.transform.position = new Vector2(TiePosition.transform.position.x - 0.5f, TiePosition.transform.position.y);
                PlayerB.transform.position = new Vector2(TiePosition.transform.position.x + 0.5f, TiePosition.transform.position.y);
                //RoundOver = true;

                ResetTheRound();
            }
            //no point for anybody
            */

            //if both flags are up (Condition B)
            //it's a tie
            //Set up another flag/ Immediately reset the stage (timer = 5 seconds, flag = false, alert.gmaeobject.setactive(false))

        }//Round isn't over

        if (RoundOver)
        {

            Debug.Log("Round " + Round);
            
            FinishedTimes[Round-1] = timer - TimeLimit;
            CurrentFinishedTime = timer;
            
            //Update the FinishedTimes Tracker

            if (ScoreBoard[0] >= WinCond || ScoreBoard[1] >= WinCond || PlayerA.health <= 0 || PlayerB.health <= 0)
            {


                if ((ScoreBoard[0] == ScoreBoard[1]))
                {
                    Debug.Log("Case A");
                    ScoreBoard[0]--;
                    ScoreBoard[1]--;
                    Round--;
                    RoundCounter--;
                }//Tie situation

                if ((PlayerA.health <= 0) && (PlayerB.health <= 0))
                {
                    Debug.Log("Case B");
                    PlayerA.health = 1;
                    PlayerB.health = 1;
                }//Tie situation


                if (ScoreBoard[0] >= WinCond)
                {
                    Debug.Log("Case C");

                    Winner = 1;
                }

                else if (ScoreBoard[1] >= WinCond)
                {
                    Debug.Log("Case D");

                    Winner = 2;
                }

                if (PlayerB.health <= 0)
                {
                    Debug.Log("Case E");

                    Debug.Log("Player 2's Health's depleted");
                    Winner = 1;
                }

                else if (PlayerA.health <= 0)
                {
                    Debug.Log("Case F");
                    Debug.Log("Player 1's Health's depleted");
                    Winner = 2;
                }



            }


            //Modify how long it takes to reset the stage after a round finishes
            ResetTimer -= Time.deltaTime;
            if(ResetTimer <= 0 && !GameOver)
            {
                Debug.Log("Resetting the round check 1");

                ResetTheRound();
            }
          
        }
    }

    public void ResetTheRound()
    {
        Debug.Log("Resetting the round check 2");

        //Deciding the winner
        if (Winner != 0)
        {
            Debug.Log("Resetting the round check 3");

            Debug.Log("A Winner has been decided");

            GameOver = true; //set this to true so you dont constantly run ResetTheRound over and over again
            switch (Winner)
            {
                case 1:
                    Player1WinScreen.gameObject.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Rematch One"));
                    EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = "HorizontalA";
                    EventSystem.current.GetComponent<StandaloneInputModule>().verticalAxis = "VerticalA";
                    EventSystem.current.GetComponent<StandaloneInputModule>().submitButton = "ClashA";

                    for (int i = 0; i < RoundCounter; i++)
                    {
                        if (FinishedTimes[i] == 0)
                             TimePrints[i].text = "Round " + i+1 + ": --:--";
                        else TimePrints[i].text = "Round " + i+1 + ": " + FinishedTimes[i]; 
                        TimePrints[i].gameObject.transform.position = new Vector2(ScorePositionA.transform.position.x, TimePrints[i].gameObject.transform.position.y);
                    }
                    //try sliding it from outside of the screen to inside the screen 
                    break;

                case 2:
                    Player2WinScreen.gameObject.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("Rematch Two"));
                    EventSystem.current.GetComponent<StandaloneInputModule>().horizontalAxis = "HorizontalB";
                    EventSystem.current.GetComponent<StandaloneInputModule>().verticalAxis = "VerticalB";
                    EventSystem.current.GetComponent<StandaloneInputModule>().submitButton = "ClashB";

                    for (int i = 0; i < RoundCounter; i++)
                    {
                        if (FinishedTimes[i] == 0)
                            TimePrints[i].text = "Round " + i+1 + ": --:--";
                        else TimePrints[i].text = "Round " + i+1 + ": " + FinishedTimes[i];
                        TimePrints[i].gameObject.transform.position = new Vector2(ScorePositionB.transform.position.x, TimePrints[i].gameObject.transform.position.y);

                    }
                    /*The single purpose for RoundCounter is to keep track of rounds instead of just the already established FinishedTimes array's length so 
                     * that the i doesn't exceed the TimePrints Array*/

                    break;
            }

            
            return;

        }

        //resetting the round
        PlayerA.transform.position = PAOriginalPosition.position;
        PlayerB.transform.position = PBOriginalPosition.position;
        timer = 0;
        MasterFlag = false;
        alert.gameObject.SetActive(false);
        PlayerA.IsHitRevert();
        StunCounterA = 0;
        PlayerAFlagUp = false;
        PlayerB.IsHitRevert();
        StunCounterB = 0;
        PlayerBFlagUp = false;
        ResetTimer = 3;


        PlayerA.Deactivate();
        PlayerB.Deactivate();
        RoundOver = false;
        RoundCounter++;
    }

    public void LocateOpponent()
    {
        if (PlayerB.gameObject.transform.position.x >= PlayerA.transform.position.x)
        {
            PlayerA.Facing = 1; //P1 facing right
            PlayerB.Facing = -1;//P2 facing left
        }

        else
        {
            PlayerB.Facing = 1; //P2 Facing Right
            PlayerA.Facing = -1;//P1 Facing Left
        }
    }
    /*
    public void CameraAdjust() {

        if (PlayerA.transform.position.y > 2 || PlayerB.transform.position.y > 2)
        {
            if (PlayerA.transform.position.y >= PlayerB.transform.position.y)
                CameraPoint.transform.position = new Vector2((PlayerA.transform.position.x + PlayerB.transform.position.x), PlayerA.transform.position.y);

            else
                CameraPoint.transform.position = new Vector2((PlayerA.transform.position.x + PlayerB.transform.position.x), PlayerB.transform.position.y);
        }

        else
        {
                CameraPoint.transform.position = new Vector2((PlayerA.transform.position.x + PlayerB.transform.position.x), 0);
        }

        if (Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x) > 4)
        {
            if (Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x) > prevDistance)
            {
                zoomAMT++;
                prevDistance = Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x);
            }

            else if (Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x) < prevDistance)
            {
                zoomAMT--;
                prevDistance = Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x);
            }

            else if (Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x) == prevDistance)
            {
                prevDistance = Math.Abs(PlayerA.transform.position.x) + Math.Abs(PlayerB.transform.position.x);
            }

        }

        else
        {
            zoomAMT = 20f;
            prevDistance = Math.Abs(4);
        }
    }
    */
}
