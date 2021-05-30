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
    void Start()
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
                Move MoveA = Instantiate(MovesList.Find(x => x.name.Contains("Move A")));//, PlayerA.transform); //object, vector2, parent
                MoveA.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveA.PlayerUser = Player.PlayerNumber;
                MoveA.transform.position = new Vector2(MoveA.transform.position.x + (float)(2.11 * Player.Facing), Player.transform.position.y);
                MoveA.transform.parent = Player.transform;
                Player.Actions[0] = MoveA;

                Move MoveB = Instantiate(MovesList.Find(x => x.name.Contains("Move B")));//, PlayerA.transform); //object, vector2, parent
                MoveB.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveB.PlayerUser = Player.PlayerNumber;
                MoveB.transform.position = new Vector2(0, Player.transform.position.y);
                MoveB.transform.parent = Player.transform;
                Player.Actions[1] = MoveB;

                Move MoveC = Instantiate(MovesList.Find(x => x.name.Contains("Move C3")));//, PlayerA.transform); //object, vector2, parent
                MoveC.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveC.PlayerUser = Player.PlayerNumber;
                MoveC.transform.position = new Vector2(MoveC.transform.position.x + (float)(3.27 * Player.Facing), Player.transform.position.y);
                MoveC.transform.parent = Player.transform;
                Player.Actions[2] = MoveC;

                Move MoveD = Instantiate(MovesList.Find(x => x.name.Contains("Move D")));//, PlayerA.transform); //object, vector2, parent
                MoveD.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveD.PlayerUser = Player.PlayerNumber;
                MoveD.transform.position = new Vector2(MoveD.transform.position.x + (float)(1*Player.Facing), Player.transform.position.y);
                MoveD.transform.parent = Player.transform;
                Player.Actions[3] = MoveD;

                break;

            case "test 2":

                MoveA = Instantiate(MovesList.Find(x => x.name.Contains("Move B")));//, PlayerA.transform); //object, vector2, parent
                MoveA.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveA.PlayerUser = Player.PlayerNumber;
                MoveA.transform.position = new Vector2(0, Player.transform.position.y);
                MoveA.transform.rotation = Player.transform.rotation;
                MoveA.transform.parent = Player.transform;
                Player.Actions[0] = MoveA;

                MoveB = Instantiate(MovesList.Find(x => x.name.Contains("Move D")));//, PlayerA.transform); //object, vector2, parent
                MoveB.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveB.PlayerUser = Player.PlayerNumber;
                MoveB.transform.position = new Vector2(MoveB.transform.position.x + (float)(1), Player.transform.position.y);
                MoveB.transform.rotation = Player.transform.rotation;

                MoveB.transform.parent = Player.transform;
                Player.Actions[1] = MoveB;

                MoveC = Instantiate(MovesList.Find(x => x.name.Contains("Move A")));//, PlayerA.transform); //object, vector2, parent
                MoveC.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveC.PlayerUser = Player.PlayerNumber;
                MoveC.transform.position = new Vector2(MoveC.transform.position.x + (float)(2.11), Player.transform.position.y);
                MoveC.transform.rotation = Player.transform.rotation;

                MoveC.transform.parent = Player.transform;
                Player.Actions[2] = MoveC;

                MoveD = Instantiate(MovesList.Find(x => x.name.Contains("Move C1")));//, PlayerA.transform); //object, vector2, parent
                MoveD.GetComponentInChildren<BoxCollider2D>().tag = "HitBox";
                MoveD.PlayerUser = Player.PlayerNumber;
                MoveD.transform.position = new Vector2(MoveD.transform.position.x, Player.transform.position.y);
                MoveD.transform.rotation = Player.transform.rotation;

                MoveD.transform.parent = Player.transform;
                Player.Actions[3] = MoveD;

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
