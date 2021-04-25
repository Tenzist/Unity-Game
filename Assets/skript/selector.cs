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
    public void lvlselect(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
}