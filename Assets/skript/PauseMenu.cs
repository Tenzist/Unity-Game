using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePause = false;
    public GameObject Pausemenu;


    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    

    public void Resume()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }
    public void Pause()
    {
        Pausemenu.SetActive(true);  
        Time.timeScale = 0f;
        GamePause = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

}
