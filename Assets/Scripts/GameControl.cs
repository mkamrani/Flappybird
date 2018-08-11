using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    [SerializeField] GameObject gameOverText;
    [SerializeField] Text scoreText;

    public static GameControl instance; // Singletone
    public float ScrollSpeed
    {
        get { return -1.5f; }
    }
    public bool GameOver { get; private set; }


    private int score = 0;



	void Awake () {
	    if (instance == null)
	    {
	        instance = this;
	    }
        else if (instance != null)
	    {
            Destroy(gameObject);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameOver && Input.GetMouseButtonDown(0))
	    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored()
    {
        if (GameOver) return;
        score++;
        scoreText.text = "Score: " + score;
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        GameOver = true;
    }
}
