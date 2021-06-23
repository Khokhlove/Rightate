using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public Text header;
    public Text score;
    public Text time;
    public GameObject infoBlock;
    public GameObject resumeButton;
    public Button exitButton;
    public GameController gameController;
    public GameObject panel;
    public GameObject highScore;

    // Start is called before the first frame update
    void Start()
    {
        Vanisher vanihser = Vanisher.GetInstance();
        exitButton.onClick.AddListener(() => {
            panel.SetActive(false);
            if (gameController.gameOver)
            {
                vanihser.VanishAndLoadMenu();
            } else
            {
                WindowController wc = WindowController.GetInstance();
                YesNoWindowUI yesNoWindow = wc.CreateYesNoWindow("Do you realy want to exit?");

                yesNoWindow.yes.onClick.AddListener(vanihser.VanishAndLoadMenu);
                yesNoWindow.no.onClick.AddListener(() => {
                    Destroy(yesNoWindow.gameObject);
                    panel.SetActive(true);
                    });
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);

        if (gameController.gameOver)
        {
            infoBlock.SetActive(true);
            score.text = Counter.GetInstance().Score.ToString();
            resumeButton.SetActive(false);
            header.text = "Game Over";
            bool newHighScore = Counter.GetInstance().Score > MusicContainer.GetInstance().selected.HighScore ? true : false;
            highScore.SetActive(newHighScore);
        } else
        {
            infoBlock.SetActive(false);
            resumeButton.SetActive(true);
            //header.text = "Game Over";
        }
    }

    public void SetHeader(string text)
    {
        header.text = text;
    }

    public void SetScore(string text)
    {
        score.text = text;
    }
    public void SetTime(string text)
    {
        time.text = text;
    }
}
