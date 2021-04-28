using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public string Name;

    public float StartTime;
    public float HangTime;
    public float AirTime; //suspend the character in the air for this amount of seconds.

    public int PlayerUser = 0; // 1 == Player 1 is using the move, 2 == Player 2 is using the move

    public Transform[] Position;

    public Collider2D[] HitBox;

    //public Sprite[] Visual;

    public SpriteRenderer[] Visuals;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
