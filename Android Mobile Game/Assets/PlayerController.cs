using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Collider2D playerCollider;
    bool moving;
    public int moves;
    Vector2 moveNormal;

    public Text movesTxt;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movesTxt.text = "Moves: " + moves;
    }


    public void Move(int direction)
    {
        if (moving == true) return;

        switch (direction)
        {
            case 1:
                playerRB.velocity = new Vector2 (0, 150);
                moveNormal = new Vector2 (0, -1);
                break;
            case 2:
                playerRB.velocity = new Vector2(0, -150);
                moveNormal = new Vector2(0, 1);
                break;
            case 3:
                playerRB.velocity = new Vector2(150, 0);
                moveNormal = new Vector2(-1, 0);
                break;
            case 4:
                playerRB.velocity = new Vector2(-150, 0);
                moveNormal = new Vector2(1, 0);
                break;

            default:
                break;
        }

        moves++;
        moving = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        ContactPoint2D contact = collision.contacts[0];
        if (collision.collider.gameObject.tag == "Obstacle")
        {   
            playerRB.velocity = new Vector2(0, 0);
            Debug.Log("Contact normal is: " + contact.normal);
            Debug.Log("Move normal is: " + moveNormal);
            moving = false;
        }

    }


}
