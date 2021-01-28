using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameState : MonoBehaviour
{
    float timer;

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
    public float ResetTimer = 3;

    public int[] Points = new int[2] {0,0};
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        alert.gameObject.SetActive(false);
        PAOriginalPosition.position = PlayerA.transform.position;
        PBOriginalPosition.position = PlayerB.transform.position;
        TiePosition.transform.position = new Vector2((PlayerA.transform.position.x + PlayerB.transform.position.x) / 2, (PlayerA.transform.position.y + PlayerB.transform.position.y) / 2);
    }


    // Update is called once per frame
    void Update()
    {
        if (!RoundOver)
        {
            timer += Time.deltaTime;


            Debug.Log("Counter = " + (int)timer);


            //MasterFlag flips
            if (timer >= 10)
            {
                alert.gameObject.SetActive(true);
                MasterFlag = true;
            }

            horizontalA = Input.GetAxisRaw("HorizontalA");
            horizontalB = Input.GetAxisRaw("HorizontalB");

            //(Input Check)
            //IF player isn't stunned

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
            //if PlayerAFlag is up, but PlayerBFlag isnt...
            if (PlayerAFlagUp && !PlayerBFlagUp)
            {
                //Play Animation
                Debug.Log("Player 1 Wins. Time: " + timer);
                Points[0]++;
                PlayerA.transform.position = new Vector2(PBOriginalPosition.transform.position.x + 2, PlayerA.transform.position.y);
                RoundOver = true;
            }
            //playerA wins. 
            //point for player A
            //if PlayerBFlag is up, but PlayerAFlag isnt...
            if (!PlayerAFlagUp && PlayerBFlagUp)
            {
                //Play Animation
                Debug.Log("Player 2 Wins. Time: " + timer);
                Points[1]++;
                PlayerB.transform.position = new Vector2(PAOriginalPosition.transform.position.x - 2, PlayerB.transform.position.y);
                RoundOver = true;
            }
            //playerB wins. 
            //point for player B            
            //if both flags are up (Condition A)
            //it's a tie
            if (PlayerAFlagUp && PlayerBFlagUp)
            {
                //Play Animation
                Debug.Log("It's a draw. Time: " + timer);
                PlayerA.transform.position = new Vector2(TiePosition.transform.position.x - 0.5f, TiePosition.transform.position.y);
                PlayerB.transform.position = new Vector2(TiePosition.transform.position.x + 0.5f, TiePosition.transform.position.y);
                RoundOver = true;
            }
            //no point for anybody
            //if both flags are up (Condition B)
            //it's a tie
            //Set up another flag/ Immediately reset the stage (timer = 5 seconds, flag = false, alert.gmaeobject.setactive(false))
        }//Round isn't over

        if (RoundOver)
        {   
            ResetTimer -= Time.deltaTime;
            if(ResetTimer <= 0)
            {
                ResetTheRound();
            }
        }
    }

    public void ResetTheRound()
    {
        
        PlayerA.transform.position = PAOriginalPosition.position;
        PlayerB.transform.position = PBOriginalPosition.position;
        timer = 0;
        MasterFlag = false;
        alert.gameObject.SetActive(false);
        PlayerAIsStunned = false;
        StunCounterA = 0;
        PlayerAFlagUp = false;
        PlayerBIsStunned = false;
        StunCounterB = 0;
        PlayerBFlagUp = false;
        ResetTimer = 3;

        RoundOver = false;
    }
}
