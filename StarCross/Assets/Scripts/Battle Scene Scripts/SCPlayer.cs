using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPlayer : MonoBehaviour
{

    //public Transform[] MovePositions;

    public string PlayerCharacter = "test";
    
    public Move[] Actions;
    public int StartupMove = -1;
    public int ActiveMove = -1;
    public float ActiveMoveTimer = 0;
    public float ActiveMoveStartsIn = 0;
    public float ActiveMoveAirTimeTypeA = 0;//Reserved for moves hat have the character hang in the air at the start of the move 
    public bool isHovering = false;
    public bool PasstheTime = false;

    public bool isInEndlag = false;
    public float currentEndlag = 0.0f;
    public float endlagMoveReference = 0.0f;

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

    public float health = 20;

    public int Facing = 1;

    public bool MoveisActive = false;

    public Transform[] MoveSpawnPos;
    //1 == facing right
    //-1 ==  facing left
    //Facing should update whenever the player is touching the ground.

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

        for (int j = 0; j < Actions.Length; j++)
        {
            Actions[j].gameObject.SetActive(true);
            Actions[j].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Facing == -1 && !isInEndlag)
        {
            //GetComponent<SpriteRenderer>().flipX = true;
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        }

        else if(Facing == 1 && !isInEndlag)
        {
            //GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        }
        if (CanMove == false || isHit == true)
        {
            //DeactivateMove();
        }
        else
        {
            //if (Input.GetKeyDown(GameManager.GM.AButtonOne)) UseMove(0);
            //if (Input.GetKeyDown(GameManager.GM.BButtonOne)) UseMove(1);
            //if (Input.GetKeyDown(GameManager.GM.CButtonOne)) UseMove(2);
            //if (Input.GetKeyDown(GameManager.GM.DButtonOne)) UseMove(3);

            //Above only applies when we're bringing in the entire GameManager object from the title screen.
            //work on that later
            if (isInEndlag == false)
            {
                if (Input.GetButtonDown(AButton)) UseMove(0);
                if (Input.GetButtonDown(BButton)) UseMove(1);
                if (Input.GetButtonDown(CButton)) UseMove(2);
                if (Input.GetButtonDown(DButton)) UseMove(3);
            }
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

            if ((ActiveMoveTimer >= ActiveMoveStartsIn) && (StartupMove != -1)) 
            {
                Debug.Log("Setting the Active Move at " + ActiveMoveTimer);
                //numberOfHitboxes = Actions[StartupMove].HitBox.Length;
               

                //Actions[StartupMove].gameObject.SetActive(true);
                //Actions[StartupMove].gameObject.SetActive(true);
                ActiveMoveTimer = 0; //acknowledge what the current active move is through number (so you know what to refer to when turning it off)

                ActiveMove = StartupMove;
                StartupMove = -1;

                MoveisActive = true;

            }

            if(ActiveMove != -1)
            {
                Debug.Log("Making Sure to Activate Move at " + ActiveMoveTimer);
                Actions[ActiveMove].gameObject.SetActive(true);
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


            if ((ActiveMove != -1) && (ActiveMoveTimer >= Actions[ActiveMove].HangTime))
            {
                Debug.Log("Deactivating Move");
                
                DeactivateMove();

            }//once enough time passes, consider the move deactive.


            //if (hurtbox.)
            //if the player comes into contact with a move that is not from the player ie. the move has a different PlayerUser value than this Player's PlayerNumber
            //then, for now ,stun the player... and Debug.Log that the player is stunned    

            if (isInEndlag == true)
                currentEndlag = currentEndlag + Time.deltaTime;
            if(currentEndlag >= endlagMoveReference)
            {
                isInEndlag = false;
                currentEndlag = 0f;
                endlagMoveReference = 0.0f;
            }

            //isInEndlag will trigger when the move deactivates
            //endlagMoveReference updates when the button to use the move is pressed, saving it for when the move deactivates.
            //that way, the value is saved even when all the other move data is tossed aside
            /*we check if passthetime is false as well. other variables could work. We just need a variable that just so happened to change depending
              on if a move was active so that we can change isInEndlag without having to put it in the UseMove function. We could just do that actually,
              but I dont want to take into account the actual amount of time it takes for a move to start and finish within the value of the endlagMoveReference
              as well
            */

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Player " + PlayerNumber + " Collision Detected");

        if (collision.gameObject.CompareTag("HitBox"))
        {
            //bug.Log("Player " + PlayerNumber + " is getting hit");
            //if (collision.GetComponentInParent<SCPlayer>().HitConfirm == true)
            //if the move is considered a hitconfirm for the opponent and the move is from the enemy, not the player themselves
            {
               //Debug.Log("Player " + collision.GetComponentInParent<SCPlayer>().PlayerNumber + " has confirmed a hit");
                if (collision.GetComponentInParent<SCPlayer>().PlayerNumber != PlayerNumber)
                {
                    //Debug.Log("Attack registered from Player " + collision.GetComponentInParent<SCPlayer>().PlayerNumber);

                    isHit = true;

                    DeactivateMove();
                    myRigidBody.AddForce(new Vector2(0, ImpulseModifier), ForceMode2D.Impulse);
                    
                    health = health - collision.GetComponentInParent<Move>().damage;
                    if (health <= 0) health = 0;
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

        this.gameObject.transform.position = new Vector2(
            this.gameObject.transform.position.x  + (Facing * Actions[i].HorDistance),
            this.gameObject.transform.position.y  + Actions[i].VerDistance);
            //  Actions[i].Position[0].transform.position; //For now these moves only put you in one set position

        Actions[i].PlayerUser = PlayerNumber; //Identify the source player, the person who's using the move

        //Start the buildup of the move (if the move has any buildup)

        ActiveMoveStartsIn = Actions[i].StartTime;
        ActiveMoveAirTimeTypeA = Actions[i].AirTime;
        PasstheTime = true;           //set up the countdown
        StartupMove = i; //THEN set the ActiveMove variable ONLY AFTER the countdown starts

        
        endlagMoveReference = Actions[i].EndLag;
        isInEndlag = true;
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
    {/*
        if (StartupMove != -1)
        {
            Actions[ActiveMove].gameObject.SetActive(false);
            Actions[ActiveMove].PlayerUser = 0;
            ActiveMove = -1;
            PasstheTime = false;
            ActiveMoveTimer = 0;
            myRigidBody.gravityScale = GravityScale;
            HitConfirm = false;
            ActiveMoveAirTimeTypeA = 0;
            ActiveMoveStartsIn = 0;
            return;
        }
        //if the player is hit before unleashing the move
        */
        //if (ActiveMove == -1) return;
        //if two characters trade moves, DeactivateMove can be activated aside from ending naturally.
        //if that's the case, just return.

        if (ActiveMove != -1)
        {
            Actions[ActiveMove].gameObject.SetActive(false);
            Actions[ActiveMove].PlayerUser = 0;
            StartupMove = -1;
            ActiveMove = -1;
            PasstheTime = false;
            ActiveMoveTimer = 0;
            myRigidBody.gravityScale = GravityScale;
            HitConfirm = false;
            ActiveMoveAirTimeTypeA = 0;
            ActiveMoveStartsIn = 0;

            numberOfHitboxes = 0;

            MoveisActive = false;

            return;

        }

        else if (StartupMove != -1)
        {
            Actions[StartupMove].gameObject.SetActive(false);
            Actions[StartupMove].PlayerUser = 0;
            StartupMove = -1;
            ActiveMove = -1;
            PasstheTime = false;
            ActiveMoveTimer = 0;
            myRigidBody.gravityScale = GravityScale;
            HitConfirm = false;
            ActiveMoveAirTimeTypeA = 0;
            ActiveMoveStartsIn = 0;

            numberOfHitboxes = 0;


            MoveisActive = false;


        }



    }

}
