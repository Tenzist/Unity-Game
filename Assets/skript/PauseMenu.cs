using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePause = false;
    public GameObject Pausemenu;



    public void Start()
    {


    }
 

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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (Input.GetKeyDown(KeyCode.Escape) && sceneName != "Menu")
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
    public void Quit()
    {
        Debug.Log("Выход...");
        Application.Quit();
    }

    public static int lvlNum = 1;
    public void Play()
    {
        SceneManager.LoadScene("lvl" + lvlNum.ToString());
    }

}
