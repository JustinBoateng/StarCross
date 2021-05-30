using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MovePool : MonoBehaviour
{
    public Move[] Moves;
    public static List<Move> MovesList = new List<Move>();
    public SCPlayer[] Player;

    // Start is called before the first frame update
    void Awake()
    {
        for (int m = 0; m < Moves.Length; m++)
        {
            MovesList.Add(Moves[m]);
        }

        MoveInstall(Player[0]);
        MoveInstall(Player[1]);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static void MoveInstall(SCPlayer Player){

        switch (Player.PlayerCharacter)
        {  

            case "test":
                Debug.Log("Instantiating moves for test");
                Move MoveA = Instantiate(MovesList.Find(x => x.name.Contains("Move A")));//, PlayerA.transform); //object, vector2, parent
                MoveA.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveA.PlayerUser = Player.PlayerNumber;
                MoveA.transform.position = Player.MoveSpawnPos[0].transform.position;
                //MoveA.transform.position = new Vector2(MoveA.transform.position.x + (float)(2.11 * Player.Facing), Player.transform.position.y);
                MoveA.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[0] = MoveA;

                Move MoveB = Instantiate(MovesList.Find(x => x.name.Contains("Move B")));//, PlayerA.transform); //object, vector2, parent
                MoveB.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveB.PlayerUser = Player.PlayerNumber;
                MoveB.transform.position = Player.MoveSpawnPos[0].transform.position;
                //MoveB.transform.position = new Vector2(0, Player.transform.position.y);
                MoveB.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[1] = MoveB;

                Move MoveC = Instantiate(MovesList.Find(x => x.name.Contains("Move C3")));//, PlayerA.transform); //object, vector2, parent
                MoveC.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveC.PlayerUser = Player.PlayerNumber;
                MoveC.transform.position = Player.MoveSpawnPos[0].transform.position;
                //MoveC.transform.position = new Vector2(MoveC.transform.position.x + (float)(3.27 * Player.Facing), Player.transform.position.y);
                MoveC.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[2] = MoveC;

                Move MoveD = Instantiate(MovesList.Find(x => x.name.Contains("Move D")));//, PlayerA.transform); //object, vector2, parent
                MoveD.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveD.PlayerUser = Player.PlayerNumber;
                MoveD.transform.position = Player.MoveSpawnPos[0].transform.position;
                //MoveD.transform.position = new Vector2(MoveD.transform.position.x + (float)(1*Player.Facing), Player.transform.position.y);
                MoveD.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[3] = MoveD;

                
                break;

            case "test 2":

                Move TwoMoveB = Instantiate(MovesList.Find(x => x.name.Contains("Move B")));//, PlayerA.transform); //object, vector2, parent
                TwoMoveB.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                TwoMoveB.PlayerUser = Player.PlayerNumber;
                TwoMoveB.transform.position = Player.MoveSpawnPos[0].transform.position;
                //TwoMoveB.transform.rotation = Player.transform.rotation;
                TwoMoveB.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[0] = TwoMoveB;

                Move TwoMoveD = Instantiate(MovesList.Find(x => x.name.Contains("Move D")));//, PlayerA.transform); //object, vector2, parent
                TwoMoveD.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                TwoMoveD.PlayerUser = Player.PlayerNumber;
                TwoMoveD.transform.position = Player.MoveSpawnPos[0].transform.position;
                //TwoMoveD.transform.rotation = Player.transform.rotation;

                TwoMoveD.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[1] = TwoMoveD;

                Move TwoMoveA = Instantiate(MovesList.Find(x => x.name.Contains("Move A")));//, PlayerA.transform); //object, vector2, parent
                TwoMoveA.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                TwoMoveA.PlayerUser = Player.PlayerNumber;
                TwoMoveA.transform.position = Player.MoveSpawnPos[0].transform.position;
                //TwoMoveA.transform.rotation = Player.transform.rotation;
                TwoMoveA.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[2] = TwoMoveA;

                Move TwoMoveCOne = Instantiate(MovesList.Find(x => x.name.Contains("Move C1")));//, PlayerA.transform); //object, vector2, parent
                TwoMoveCOne.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                TwoMoveCOne.PlayerUser = Player.PlayerNumber;
                TwoMoveCOne.transform.position = Player.MoveSpawnPos[0].transform.position;
                //TwoMoveCOne.transform.rotation = Player.transform.rotation;
                TwoMoveCOne.transform.parent = Player.MoveSpawnPos[0].transform;
                Player.Actions[3] = TwoMoveCOne;

                break;
        }

        for (int j = 0; j < Player.Actions.Length; j++)
        {
            Player.Actions[j].gameObject.SetActive(true);

        }
        /*This is important so that the first time a move is used it can actually appear. 
               We need to call setActive for it at least once.
               In SCPlayer, it will setActive it back to false at start. 
               SetActive being true NEEDS to be first, hence why we made this into an Awake Function.
               ...theouretically, we could've just put this in a different Awake function within the same class though.
               */

    }
}
