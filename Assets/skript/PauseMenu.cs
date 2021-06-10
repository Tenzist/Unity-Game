using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePause = false;
    public static bool cheat = false;
    public GameObject Pausemenu;
    public static int lvlNum = 1;
    public GameObject CheatMenu;

    public void Start()
    {
        Time.timeScale = 1f;
    }
 
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (Input.GetKeyDown(KeyCode.Escape) && sceneName != "Menu" && cheat == false)
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

        if (Input.GetKeyDown(KeyCode.Insert) && sceneName != "Menu")
        {
            if (cheat == false)
            {
                chmenuOn();
            }
            else
            {
                chmenuOff();
            }
        }
    }
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void chmenuOn()
    {
        CheatMenu.SetActive(true);
        cheat = true;
    }
    public void chmenuOff()
    {
        CheatMenu.SetActive(false);
        cheat = false;
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
        Audio.aud.Stop();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Выход...");
        Application.Quit();
    }
    public void Play()
    {
        Invoke("play", 1f);
    }
    public void play()
    {
        SceneManager.LoadScene("lvl" + lvlNum.ToString());
    }

}
