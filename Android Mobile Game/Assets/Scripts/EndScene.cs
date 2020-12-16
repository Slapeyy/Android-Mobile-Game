using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public GameObject EndScreen;
    public Text StarRatingText;
    int maxGems;
    public int movesLeftForWin;

    private void Start()
    {
        maxGems = GameObject.FindGameObjectsWithTag("Gem").Length;
    }

    public void EndGame(int gems, int moves)
    {
        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            EndScreen.SetActive(true);

            if (gems == maxGems && moves >= movesLeftForWin)
                StarRatingText.text = "You have finished the Tutorial Level with a GOLD star rating!";
            else if (gems < maxGems && moves >= movesLeftForWin)
                StarRatingText.text = "You have finished the Tutorial Level with a SILVER star rating!";
            else if (gems < maxGems && moves < movesLeftForWin)
                StarRatingText.text = "You have finished the Tutorial Level with a BRONZE star rating!";


                            
        }    
    }

    private void Update()
    {
        if(EndScreen.activeSelf == true && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerController player = collider.GetComponent<PlayerController>();
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            EndGame(player.gems, player.moves);
            player.Reset();
        }
    }

}
