using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private bool _p1IsFacingRight;
    //private bool _hasFlipped;

    // Start is called before the first frame update
    void Start()
    {
        _p1IsFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.transform.position.x < Player2.transform.position.x)
        {
            //Debug.Log("Player 1 is on the left");
            //Player1.gameObject.GetComponent<FighterStats>().facingright = true;
            //Player2.gameObject.GetComponent<FighterStats>().facingright = false;

            if (!_p1IsFacingRight)
            {
                Flip(Player1.transform);
                Flip(Player2.transform);
                _p1IsFacingRight = true;
            }
        }
        else
        {
            //Player1.gameObject.GetComponent<FighterStats>().facingright = false;
            //Player2.gameObject.GetComponent<FighterStats>().facingright = true;

            if (_p1IsFacingRight)
            {
                Flip(Player2.transform);
                Flip(Player1.transform);
                _p1IsFacingRight = false;
            }
        }
    }

    void Flip(Transform player)
    {
        player.localScale = new Vector3(-player.localScale.x, player.localScale.y, 1);
    }
}
