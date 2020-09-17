using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    float score;
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("Score").GetComponent<Text>();
        TitleUpd();
    }

    public void OnClick (int num)
    {
        switch (num)
        {
            case 0:
                SceneManager.LoadScene("Main");
                break;
            case 1:
                PlayerPrefs.DeleteAll();
                TitleUpd();
                break;
        }
    }

    void TitleUpd ()
    {
        score = PlayerPrefs.GetFloat ("SCORE", 999.9f);
        ScoreText.text = "Best Time\r\n   " + score.ToString("000.0") + "s";
    }
}
