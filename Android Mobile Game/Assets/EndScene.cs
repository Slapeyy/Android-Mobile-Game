using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject EndScreen;
    public void EndGame()
    {
        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else { EndScreen.SetActive(true); }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EndGame();
        }
    }

}
