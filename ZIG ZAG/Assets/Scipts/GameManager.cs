using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gamestart;
    public int score;
    public Text scoretext;
    public Text highscore;

    private void Awake()
    {

        highscore.text = "best:"+Gamehighscore().ToString();
    }
    public void StartGame()
    {
        gamestart = true;
        FindObjectOfType<createroad>().startbuild();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void Endgame()
    {
        SceneManager.LoadScene(0);
    }
    public void Incscore()
    {
        score++;
        scoretext.text = score.ToString();
        if (score > Gamehighscore())
        {
            PlayerPrefs.SetInt("highscore",score);
            highscore.text ="best:"+ score.ToString();  
        }


    }
    public int Gamehighscore()
    {
        int i = PlayerPrefs.GetInt("highscore");
        return i;
    }
}
