using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    [SerializeField]
    private GameObject[] Rocks;

    private bool isGreenRockUnlocked, isRedRockUnlocked;

    //[SerializeField]
    //private Animator notificationAnim;

    //[SerializeField]
    //private Text notificationText;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        Rocks[GameController.instance.GetSelectedRock()].SetActive(true);
        CheckIfRocksAreUnlocked();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void CheckIfRocksAreUnlocked()
    {
        if (GameController.instance.IsRedRockUnlocked() == 1)
        {
            isRedRockUnlocked = true;
        }

        if (GameController.instance.IsGreenRockUnlocked() == 1)
        {
            isGreenRockUnlocked = true;
        }
    }

    public void PlayGame()
    {
        SceneFader.instance.FadeIn("Game");
    }

    public void ConnectOnGooglePlayGames()
    {
        LeaderboardsController.instance.ConnectOrDisconnectOnGooglePlayGames();
    }

    public void OpenLeaderboardsScoreUI()
    {
        LeaderboardsController.instance.OpenLeaderboardsScore();
    }

    //public void ConnectOnTwitter()
    //{
    //    SocialMediaController.instance.LogInOrLogOutTwitter();
    //}

    //public void ShareOnTwitter()
    //{
    //    SocialMediaController.instance.ShareOnTwitter();
    //}

    public void ChangeRock()
    {

        if (GameController.instance.GetSelectedRock() == 0)
        {

            if (isGreenRockUnlocked)
            {
                Rocks[0].SetActive(false);
                GameController.instance.SetSelectedRock(1);
                Rocks[GameController.instance.GetSelectedRock()].SetActive(true);
            }

        }
        else if (GameController.instance.GetSelectedRock() == 1)
        {

            if (isRedRockUnlocked)
            {

                Rocks[1].SetActive(false);
                GameController.instance.SetSelectedRock(2);
                Rocks[GameController.instance.GetSelectedRock()].SetActive(true);

            }
            else
            {

                Rocks[1].SetActive(false);
                GameController.instance.SetSelectedRock(0);
                Rocks[GameController.instance.GetSelectedRock()].SetActive(true);

            }

        }
        else if (GameController.instance.GetSelectedRock() == 2)
        {
            Rocks[2].SetActive(false);
            GameController.instance.SetSelectedRock(0);
            Rocks[GameController.instance.GetSelectedRock()].SetActive(true);
        }

    }

    //public void NotificationMessage(string message)
    //{
    //    StartCoroutine(AnimateNotificationPanel(message));
    //}

    //IEnumerator AnimateNotificationPanel(string message)
    //{
    //    notificationAnim.Play("SlideIn");
    //    notificationText.text = message;
    //    yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(2f));
    //    notificationAnim.Play("SlideOut");
    //}
}
