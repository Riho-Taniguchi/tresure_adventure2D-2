using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCont : MonoBehaviour
{
    Hud UIScript;

    // Start is called before the first frame update
    void Start()
    {
        UIScript = GameObject.Find("Canvas").GetComponent<Hud>();
    }

    public void OnClick (int num)
    {
        switch (num)
        {
            case 0:
                UIScript.OpenCont();
                break;
            case 1:
                SceneManager.LoadScene("Main");
                break;
            case 2:
                SceneManager.LoadScene("Title");
                break;
        }
    }
}
