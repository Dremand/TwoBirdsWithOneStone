using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    private const string HIGH_SCORE = "High Score";
    private const string SELECTED_STONE= "Selected Stone";
    private const string GREEN_STONE = "Green Stone";
    private const string RED_STONE = "Red Stone";

    void Awake()
    {
        MakeSingleton();
        IsTheGameStartedForTheFirstTime();
        //		PlayerPrefs.DeleteAll ();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void IsTheGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SELECTED_STONE, 0);
            PlayerPrefs.SetInt(GREEN_STONE, 0);
            PlayerPrefs.SetInt(RED_STONE, 0);
            PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 0);
        }
    }

    public void SetHighscore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void SetSelectedRock(int selectedRock)
    {
        PlayerPrefs.SetInt(SELECTED_STONE, selectedRock);
    }

    public int GetSelectedRock()
    {
        return PlayerPrefs.GetInt(SELECTED_STONE);
    }

    public void UnlockGreenRock()
    {
        PlayerPrefs.SetInt(GREEN_STONE, 0);
    }

    public int IsGreenRockUnlocked()
    {
        return PlayerPrefs.GetInt(GREEN_STONE);
    }

    public void UnlockRedRock()
    {
        PlayerPrefs.SetInt(RED_STONE, 0);
    }

    public int IsRedRockUnlocked()
    {
        return PlayerPrefs.GetInt(RED_STONE);
    }
}
