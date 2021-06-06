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

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(() => {
            if (gameController.gameOver)
            {
                LevelLoader.LoadLevel(0);
            } else
            {
                WindowController wc = WindowController.GetInstance();
                YesNoWindowUI yesNoWindow = wc.CreateYesNoWindow("Do you realy want to exit?");

                yesNoWindow.yes.onClick.AddListener(() => LevelLoader.LoadLevel(0));
                yesNoWindow.no.onClick.AddListener(() => Destroy(yesNoWindow.gameObject));
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
