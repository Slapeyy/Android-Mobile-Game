using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SwipeMotion swipeControl;
    Rigidbody2D playerRB;
    Collider2D playerCollider;
    RectTransform thisRect;
    bool moving;
    public int moves;
    Vector2 moveNormal;

    public Text movesTxt;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        thisRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeControl.SwipeUp)
            Move(1);
        if (swipeControl.SwipeD)
            Move(2);
        if (swipeControl.SwipeR)
            Move(3);
        if (swipeControl.SwipeL)
            Move(4);

        movesTxt.text = "Moves: " + moves;
    }


    public void Move(int direction)
    {
        if (moving == true) { Debug.Log("Still Moving"); return; }

        //Up = 1, Down = 2, Right = 3, Left = 4
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
            
            float m_x = thisRect.localPosition.x;
            float m_y = thisRect.localPosition.y;
            Debug.Log("Contact normal is: " + contact.normal);
            Debug.Log("X pos at hit is: " + m_x);
            Debug.Log("Y pos at hit is: " + m_y);
            moving = false;

            if (contact.normal.x == -1)
                m_x = m_x - 10;

            else if (contact.normal.x == 1)
                m_x = m_x + 10;

            if (contact.normal.y == -1)
                m_y = m_y - 10;

            else if (contact.normal.y == 1)
                m_y = m_y + 10;

            thisRect.localPosition = new Vector3 (m_x, m_y, thisRect.localPosition.z);
            Debug.Log("X pos after hit is: " + thisRect.localPosition.x);
            Debug.Log("Y pos after hit is: " + thisRect.localPosition.y);
        }

    }


}
