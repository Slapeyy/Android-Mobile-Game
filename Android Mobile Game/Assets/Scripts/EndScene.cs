using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public GameObject EndScreen;
    public Text starRatingText;
    public Text levelText;

    int maxGems;
    public int movesLeftForWin;

    private void Start()
    {
        maxGems = GameObject.FindGameObjectsWithTag("Gem").Length;
        levelText.text = SceneManager.GetActiveScene().buildIndex.ToString();
        if (SceneManager.GetActiveScene().buildIndex == 0)
            levelText.text = "Tutorial";
    }

    public void EndGame(int gems, int moves)
    {
        EndScreen.SetActive(true);
        if (gems == maxGems && moves >= movesLeftForWin)
            starRatingText.text = "You have finished Level: " + SceneManager.GetActiveScene().buildIndex + " with a GOLD star rating!";
        else if (gems < maxGems && moves >= movesLeftForWin)
            starRatingText.text = "You have finished Level: " + SceneManager.GetActiveScene().buildIndex + " with a SILVER star rating!";
        else if (gems < maxGems && moves < movesLeftForWin)
            starRatingText.text = "You have finished Level: " + SceneManager.GetActiveScene().buildIndex + "  with a BRONZE star rating!";                
    }
    public void NextLevel() 
    {
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
