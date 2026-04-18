using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Star_btn()
    {

        SceneManager.LoadScene("Main");

    }
    public void Settings_btn()
    {

        //SceneManager.LoadScene(2);
        
    }

    public void Exit_btn()
    {

        Application.Quit();

    }

}
