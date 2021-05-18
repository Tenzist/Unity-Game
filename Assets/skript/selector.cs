using UnityEngine.SceneManagement;
using UnityEngine;

public class selector : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject LevelSelection;


    public void Select()
    {
        LevelSelection.SetActive(true);
        Buttons.SetActive(false);
    }
    public void BackToMenu()
    {
        LevelSelection.SetActive(false);
        Buttons.SetActive(true);
    }

    public void lvlselect(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && LevelSelection == true)
        {
            LevelSelection.SetActive(false);
            Buttons.SetActive(true);
        }
    }

}