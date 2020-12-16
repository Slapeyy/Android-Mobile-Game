using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SwipeMotion swipeControl;
    public int moves;
    public int gems;
    public List<Sprite> player_anim;
    public Text movesTxt;

    Rigidbody2D playerRB;
    Collider2D playerCollider;
    RectTransform thisRect;
    Image playerSprite;

    bool moving;
    Vector2 moveNormal;

    LayerMask obstacleMask;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        thisRect = GetComponent<RectTransform>();
        playerSprite = GetComponent<Image>();
        obstacleMask = LayerMask.GetMask("Obstacle");
        movesTxt = GameObject.FindGameObjectWithTag("MovesTxt").GetComponent<Text>();
        Reset();
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

        if (playerCollider.IsTouchingLayers(obstacleMask)) 
        {
            float m_x = thisRect.localPosition.x;
            float m_y = thisRect.localPosition.y;

            if (playerSprite.sprite == player_anim[4])
            {
                m_x = m_x - 10;
                playerSprite.sprite = player_anim[9];
            }

            else if (playerSprite.sprite == player_anim[2])
            {
                m_x = m_x + 10;
                playerSprite.sprite = player_anim[6];
            }

            if (playerSprite.sprite == player_anim[11])
            {
                m_y = m_y - 10;
                playerSprite.sprite = player_anim[5];
            }

            else if (playerSprite.sprite == player_anim[8])
            {
                m_y = m_y + 10;
                playerSprite.sprite = player_anim[0];

            }

            thisRect.localPosition = new Vector3(m_x, m_y, thisRect.localPosition.z);

        }
        movesTxt.text = moves.ToString();
    }


    public void Move(int direction)
    {
        if (moving == true || moves <1) 
        { 
            Debug.Log("Still Moving"); 
            return; 
        }

            //Up = 1, Down = 2, Right = 3, Left = 4
        switch (direction)
        {
            case 1:
                playerRB.velocity = new Vector2 (0, 150);
                moveNormal = new Vector2 (0, -1);
                playerSprite.sprite = player_anim[4];
                break;
            case 2:
                playerRB.velocity = new Vector2(0, -150);
                moveNormal = new Vector2(0, 1);
                playerSprite.sprite = player_anim[2];
                break;
            case 3:
                playerRB.velocity = new Vector2(150, 0);
                moveNormal = new Vector2(-1, 0);
                playerSprite.sprite = player_anim[11];
                break;
            case 4:
                playerRB.velocity = new Vector2(-150, 0);
                moveNormal = new Vector2(1, 0);
                playerSprite.sprite = player_anim[8];
                break;

            default:
                break;
        }

        moves--;
        moving = true;
    }

    public void Reset()
    {
        moves = int.Parse(movesTxt.text);
        moving = false;
        gems = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        ContactPoint2D contact = collision.contacts[0];
        if (collision.collider.gameObject.tag == "Obstacle")
        {   
            playerRB.velocity = new Vector2(0, 0);
            
            float m_x = thisRect.localPosition.x;
            float m_y = thisRect.localPosition.y;
            //Debug.Log("Contact normal is: " + contact.normal);
            //Debug.Log("X pos at hit is: " + m_x);
            //Debug.Log("Y pos at hit is: " + m_y);
            moving = false;

            if (contact.normal.x == -1)
            {
                m_x = m_x - 10;
                playerSprite.sprite = player_anim[9];
            }

            else if (contact.normal.x == 1)
            {
                m_x = m_x + 10;
                playerSprite.sprite = player_anim[6];
            }

            if (contact.normal.y == -1)
            {
                m_y = m_y - 10;
                playerSprite.sprite = player_anim[5];
            }

            else if (contact.normal.y == 1)
            {
                m_y = m_y + 10;
                playerSprite.sprite = player_anim[0];
                
            }

            thisRect.localPosition = new Vector3 (m_x, m_y, thisRect.localPosition.z);
            
            //Debug.Log("Y pos after hit is: " + thisRect.localPosition.y);
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            gems++;
            Destroy(collision.gameObject);
                
        }
    }

}
