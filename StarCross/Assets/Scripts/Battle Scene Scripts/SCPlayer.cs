using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPlayer : MonoBehaviour
{

    //public Transform[] MovePositions;

    public Move[] Actions;
    public int StartupMove = -1;
    public int ActiveMove = -1;
    public float ActiveMoveTimer = 0;
    public float ActiveMoveStartsIn = 0;
    public float ActiveMoveAirTimeTypeA = 0;//Reserved for moves hat have the character hang in the air at the start of the move 
    public bool isHovering = false;
    public bool PasstheTime = false;

    public float fallmultiplier = 2.5f;

    public int PlayerNumber;
    public string AButton;
    public string BButton;
    public string CButton;
    public string DButton;

    public bool CanMove = false;

    //public BoxCollider2D hurtbox;
    //the player collider will act as the hurtbox, detecting the hitboxes of other moves
    public BoxCollider2D myStandingCollider;
    public Rigidbody2D myRigidBody;
    public float GravityScale;

    public bool isHit = false;
    public bool HitConfirm = false;
    public int numberOfHitboxes = 0;

    public float ImpulseModifier = 30;

    public int health = 10;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerNumber == 1)
        {
            AButton = "AKeyOne";
            BButton = "BKeyOne";
            CButton = "CKeyOne";
            DButton = "DKeyOne";

        }
        else if (PlayerNumber == 2)
        {
            AButton = "AKeyTwo";
            BButton = "BKeyTwo";
            CButton = "CKeyTwo";
            DButton = "DKeyTwo";
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        GravityScale = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == false || isHit == true) { }
        else
        {
            //if (Input.GetKeyDown(GameManager.GM.AButtonOne)) UseMove(0);
            //if (Input.GetKeyDown(GameManager.GM.BButtonOne)) UseMove(1);
            //if (Input.GetKeyDown(GameManager.GM.CButtonOne)) UseMove(2);
            //if (Input.GetKeyDown(GameManager.GM.DButtonOne)) UseMove(3);

            //Above only applies when we're bringing in the entire GameManager object from the title screen.
            //work on that later

            if (Input.GetButtonDown(AButton)) UseMove(0);
            if (Input.GetButtonDown(BButton)) UseMove(1);
            if (Input.GetButtonDown(CButton)) UseMove(2);
            if (Input.GetButtonDown(DButton)) UseMove(3);

            if(PasstheTime == true)
            {
                ActiveMoveTimer += Time.deltaTime;
                 //keep track of how many hitboxes we'll be throwing out
            }

            if ((ActiveMoveTimer < ActiveMoveAirTimeTypeA) && PasstheTime) myRigidBody.gravityScale = 0; 
            else myRigidBody.gravityScale = GravityScale;
            //while enough time hasn't passed yet, hold the character in the air
            //This has to be detached from the check for if the move started or finished yet
            //PasstheTime is being checked too. PasstheTime becomes false when any move is Deactivated via the Deactivate function.
            //Putting the check here is just a safety measure since there are some cases where ActiveMoveTimer forever remains less than ActiveMoveAirTime

            if (myRigidBody.velocity.y < 0)
            {
                myRigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
            } //Better Falling speed equation

            if ((ActiveMoveTimer > ActiveMoveStartsIn) && (StartupMove != -1)) 
            {
                Debug.Log("Activating Move at " + ActiveMoveTimer);
                numberOfHitboxes = Actions[StartupMove].HitBox.Length;
                Actions[StartupMove].gameObject.SetActive(true);
                ActiveMoveTimer = 0; //acknowledge what the current active move is through number (so you know what to refer to when turning it off)

                ActiveMove = StartupMove;
                StartupMove = -1;



            }
            //ActiveMoveTimer can only be greater than ActiveMoveStartsin if a Move was used.
            //when it does become greater, actually ACTIVATE the move, then reset the timer
            /*
            if (ActiveMove != -1)
            {
                if (numberOfHitboxes == 3)
                    if (
                            (Actions[ActiveMove].HitBox[0].IsTouchingLayers(9))||
                            (Actions[ActiveMove].HitBox[1].IsTouchingLayers(9))||
                            (Actions[ActiveMove].HitBox[2].IsTouchingLayers(9))
                       )
                HitConfirm = true;

                else if (numberOfHitboxes == 2)
                    if (
                            (Actions[ActiveMove].HitBox[0].IsTouchingLayers(9)) ||
                            (Actions[ActiveMove].HitBox[1].IsTouchingLayers(9))
                       )
                HitConfirm = true;

                else if ((Actions[ActiveMove].HitBox[0].IsTouchingLayers(9))) HitConfirm = true;

            }
            */
            //If the move hits something in the Hurtbox Layer, aka, a player
            //Then yes, the hit connected
            //do the same for any other hitboxes


            if ((ActiveMove != -1) && (ActiveMoveTimer > Actions[ActiveMove].HangTime))
            {
                DeactivateMove();

            }//once enough time passes, consider the move deactive.


            //if (hurtbox.)
            //if the player comes into contact with a move that is not from the player ie. the move has a different PlayerUser value than this Player's PlayerNumber
            //then, for now ,stun the player... and Debug.Log that the player is stunned    

            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player " + PlayerNumber + " Collision Detected");

        if (collision.gameObject.CompareTag("HitBox"))
        {
            Debug.Log("Player " + PlayerNumber + " is getting hit");
            //if (collision.GetComponentInParent<SCPlayer>().HitConfirm == true)
            //if the move is considered a hitconfirm for the opponent and the move is from the enemy, not the player themselves
            {
                Debug.Log("Player " + collision.GetComponentInParent<SCPlayer>().PlayerNumber + " has confirmed a hit");
                if (collision.GetComponentInParent<SCPlayer>().PlayerNumber != PlayerNumber)
                {
                    Debug.Log("Attack registered from Player " + collision.GetComponentInParent<SCPlayer>().PlayerNumber);

                    isHit = true;

                    myRigidBody.AddForce(new Vector2(0, ImpulseModifier), ForceMode2D.Impulse);
                    DeactivateMove();
                    health--;
                }
            }
        }
        /*If the collision that is touching the player is that of a 
        Hitbox
        that belongs NOT to this player...
    
          Then announce that a hit has been scored.
          */
        else if (!collision) { }
    

        else return;

    }
    //Detect if the player got hit by a move
    //attaches to the main body of the player

    public void UseMove(int i)
    {
        this.gameObject.transform.position = Actions[i].Position[0].transform.position; //For now these moves only put you in one set position

        Actions[i].PlayerUser = PlayerNumber; //Identify the source player, the person who's using the move

        //Start the buildup of the move (if the move has any buildup)

        ActiveMoveStartsIn = Actions[i].StartTime;
        ActiveMoveAirTimeTypeA = Actions[i].AirTime;
        PasstheTime = true;           //set up the countdown
        StartupMove = i; //THEN set the ActiveMove variable ONLY AFTER the countdown starts
    }

    public void Activate()
    {
        CanMove = true;
    }

    public void Deactivate()
    {
        CanMove = false;
    }

    public void IsHitRevert()
    {
        isHit = false;
    }

    public void DeactivateMove()
    {
        if (ActiveMove == -1) return;
        //if two characters trade moves, DeactivateMove can be activated aside from ending naturally.
        //if that's the case, just return.

        Actions[ActiveMove].gameObject.SetActive(false);
        Actions[ActiveMove].PlayerUser = 0;
        ActiveMove = -1;
        PasstheTime = false;
        ActiveMoveTimer = 0;
        myRigidBody.gravityScale = GravityScale;
        HitConfirm = false;
    }

}
