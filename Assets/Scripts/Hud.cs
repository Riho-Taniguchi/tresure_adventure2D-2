using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    bool clear;
    int count;
    float now;
    float score;
    Player PlayerScript;
    Text TimeText;
    Text ClearText;
    Text HighText;
    Image[] ChestMark = new Image[3];
    public Button Open;
    Button Restart, Back;

    // Start is called before the first frame update
    void Start()
    {
        clear = false;
        count = 0;
        now = 0.0f;
        score = PlayerPrefs.GetFloat ("SCORE", 999.9f);
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
        Open.gameObject.SetActive (false);
        TimeText = GameObject.Find("Time").GetComponent<Text>();
        ClearText = GameObject.Find("Clear").GetComponent<Text>();
        ClearText.gameObject.SetActive (false);
        HighText = GameObject.Find("High").GetComponent<Text>();
        HighText.gameObject.SetActive (false);
        ChestMark[0] = GameObject.Find("ChestMark1").GetComponent<Image>();
        ChestMark[1] = GameObject.Find("ChestMark2").GetComponent<Image>();
        ChestMark[2] = GameObject.Find("ChestMark3").GetComponent<Image>();
        Restart = GameObject.Find("Restart").GetComponent<Button>();
        Restart.gameObject.SetActive (false);
        Back = GameObject.Find("Back").GetComponent<Button>();
        Back.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!clear)
        {
            now += Time.deltaTime;
            TimeText.text = "Time : " + now.ToString("000.0");
        }
    }

    public void OpenCont ()
    {
        ChestMark[count].color = Color.white;
        count += 1;
        Destroy(PlayerScript.Col);
        if (count == 3)
        {
            clear = true;
            ClearText.gameObject.SetActive (true);
            if (score > now)
            {
                HighText.gameObject.SetActive (true);
                PlayerPrefs.SetFloat ("SCORE", now);
                PlayerPrefs.Save ();
            }
            Restart.gameObject.SetActive (true);
            Back.gameObject.SetActive (true);
        }
    }
}
