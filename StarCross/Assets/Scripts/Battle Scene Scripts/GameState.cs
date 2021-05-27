using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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


    public Move[] MovePool;
    public Move MovePrefab;

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



        //Establishing Move Pools

        switch (PlayerA.PlayerCharacter)
        {
            case "test":
                Move MoveA = Instantiate(MovePool[0]);//, PlayerA.transform); //object, vector2, parent
                MoveA.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveA.PlayerUser = PlayerA.PlayerNumber;               
                MoveA.transform.position = new Vector2(MoveA.transform.position.x, PlayerA.transform.position.y);
                MoveA.transform.parent = PlayerA.transform;
                PlayerA.Actions[0] = MoveA;

                Move MoveB = Instantiate(MovePool[1]);//, PlayerA.transform); //object, vector2, parent
                MoveB.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveB.PlayerUser = PlayerA.PlayerNumber;               
                MoveB.transform.position = new Vector2(MoveB.transform.position.x, PlayerA.transform.position.y);
                MoveB.transform.parent = PlayerA.transform;
                PlayerA.Actions[1] = MoveB;

                Move MoveC = Instantiate(MovePool[2]);//, PlayerA.transform); //object, vector2, parent
                MoveC.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveC.PlayerUser = PlayerA.PlayerNumber;               
                MoveC.transform.position = new Vector2(MoveC.transform.position.x, PlayerA.transform.position.y);
                MoveC.transform.parent = PlayerA.transform;
                PlayerA.Actions[2] = MoveC;

                Move MoveD = Instantiate(MovePool[3]);//, PlayerA.transform); //object, vector2, parent
                MoveD.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveD.PlayerUser = PlayerA.PlayerNumber;              
                MoveD.transform.position = new Vector2(MoveD.transform.position.x, PlayerA.transform.position.y);
                MoveD.transform.parent = PlayerA.transform;
                PlayerA.Actions[3] = MoveD;

                /*
                Move MoveA = Instantiate(MovePool[0]);
                MoveA.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[0] = MoveA;

                
                Move MoveB = Instantiate(MovePool[1]);
                MoveB.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[1] = MoveB;

                Move MoveC = Instantiate(MovePool[2]);
                MoveC.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[2] = MoveC;


                Move MoveD = Instantiate(MovePool[4]);
                MoveD.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[3] = MoveD;
                */

                for (int j = 0; j < PlayerA.Actions.Length; j++)
                {
                    PlayerA.Actions[j].gameObject.SetActive(true);
                   
                }
                /*This is important so that the first time a move is used it can actually appear. 
                We need to call setActive for it at least once.
                In SCPlayer, it will setActive it back to false at start. 
                SetActive being true NEEDS to be first, hence why we made this into an Awake Function.
                ...theouretically, we could've just put this in a different Awake function within the same class though.
                */

                break;

            case "test 2":

                Move MoveE = Instantiate(MovePool[1], PlayerA.transform); //object, vector2, parent
                MoveE.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveE.PlayerUser = PlayerA.PlayerNumber;
                //MoveE.transform.position = PlayerA.transform.position;
                PlayerA.Actions[0] = MoveE;

                Move MoveF = Instantiate(MovePool[4], PlayerA.transform); //object, vector2, parent
                MoveF.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveF.PlayerUser = PlayerA.PlayerNumber;
                //MoveF.transform.position = PlayerA.transform.position;
                PlayerA.Actions[1] = MoveF;

                Move MoveG = Instantiate(MovePool[0], PlayerA.transform); //object, vector2, parent
                MoveG.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveG.PlayerUser = PlayerA.PlayerNumber;
                //MoveG.transform.position = PlayerA.transform.position;
                PlayerA.Actions[2] = MoveG;

                Move MoveH = Instantiate(MovePool[3], PlayerA.transform); //object, vector2, parent
                MoveH.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveH.PlayerUser = PlayerA.PlayerNumber;
                //MoveH.transform.position = PlayerA.transform.position;
                PlayerA.Actions[3] = MoveH;
                /*
                Move MoveE = Instantiate(MovePool[1]);
                MoveE.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[0] = MoveE;

                Move MoveF = Instantiate(MovePool[5]);
                MoveF.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[1] = MoveF;

                Move MoveG = Instantiate(MovePool[0]);
                MoveG.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[2] = MoveG;

                Move MoveH = Instantiate(MovePool[3]);
                MoveH.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[3] = MoveH;
                */
                break;
        }

        switch (PlayerB.PlayerCharacter)
        {
            case "test":
                Move MoveA = Instantiate(MovePool[0], PlayerB.transform); //object, vector2, parent
                MoveA.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveA.PlayerUser = PlayerB.PlayerNumber;
                //MoveA.transform.position = PlayerB.transform.position;
                PlayerB.Actions[0] = MoveA;

                Move MoveB = Instantiate(MovePool[1], PlayerB.transform); //object, vector2, parent
                MoveB.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveB.PlayerUser = PlayerB.PlayerNumber;
                //MoveB.transform.position = PlayerB.transform.position;
                PlayerB.Actions[1] = MoveB;

                Move MoveC = Instantiate(MovePool[2], PlayerB.transform); //object, vector2, parent
                MoveC.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveC.PlayerUser = PlayerB.PlayerNumber;
                //MoveC.transform.position = PlayerB.transform.position;
                PlayerB.Actions[2] = MoveC;

                Move MoveD = Instantiate(MovePool[3], PlayerB.transform); //object, vector2, parent
                MoveD.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveD.PlayerUser = PlayerB.PlayerNumber;
                //MoveD.transform.position = PlayerB.transform.position;
                PlayerB.Actions[3] = MoveD;

                /*
                Move MoveA = Instantiate(MovePool[0]);
                MoveA.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[0] = MoveA;

                
                Move MoveB = Instantiate(MovePool[1]);
                MoveB.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[1] = MoveB;

                Move MoveC = Instantiate(MovePool[2]);
                MoveC.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[2] = MoveC;


                Move MoveD = Instantiate(MovePool[4]);
                MoveD.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[3] = MoveD;
                */
                break;

            case "test 2":

                Move MoveE = Instantiate(MovePool[1], PlayerB.transform); //object, vector2, parent
                MoveE.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveE.PlayerUser = PlayerB.PlayerNumber;
               //MoveE.transform.position = PlayerB.transform.position;
                PlayerB.Actions[0] = MoveE;

                Move MoveF = Instantiate(MovePool[4], PlayerB.transform); //object, vector2, parent
                MoveF.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveF.PlayerUser = PlayerB.PlayerNumber;
                //MoveF.transform.position = PlayerB.transform.position;
                PlayerB.Actions[1] = MoveF;

                Move MoveG = Instantiate(MovePool[0], PlayerB.transform); //object, vector2, parent
                MoveG.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveG.PlayerUser = PlayerB.PlayerNumber;
                //MoveG.transform.position = PlayerB.transform.position;
                PlayerB.Actions[2] = MoveG;

                Move MoveH = Instantiate(MovePool[3], PlayerB.transform); //object, vector2, parent
                MoveH.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveH.PlayerUser = PlayerB.PlayerNumber;
                //MoveH.transform.position = PlayerB.transform.position;
                PlayerB.Actions[3] = MoveH;
                /*
                Move MoveE = Instantiate(MovePool[1]);
                MoveE.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[0] = MoveE;

                Move MoveF = Instantiate(MovePool[5]);
                MoveF.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[1] = MoveF;

                Move MoveG = Instantiate(MovePool[0]);
                MoveG.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[2] = MoveG;

                Move MoveH = Instantiate(MovePool[3]);
                MoveH.gameObject.transform.parent = PlayerA.gameObject.transform;
                PlayerA.Actions[3] = MoveH;
                */
                
                break;
        }

        //Read each players' character code, and assign to them their Moves associated to their character
    }

    //Start and Awake work in similar ways except that Awake is called first and, unlike Start, will be called even if the script component is disabled.

    // Update is called once per frame
    void Update()
    {
        LocateOpponent();

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
}
