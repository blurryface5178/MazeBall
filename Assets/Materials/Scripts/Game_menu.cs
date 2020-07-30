using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_menu : MonoBehaviour {


    public void click(int x)
    {
        if (x==1)
        {
            SceneManager.LoadScene("Scenes");
        }
        else if (x==2)
        {
            Application.Quit();
        }

    }
}
