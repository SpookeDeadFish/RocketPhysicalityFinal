using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }
    public void loadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public void loadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void loadLevelThree()
    {
        SceneManager.LoadScene("LukeScnee");
    }
    public void loadLevelFour()
    {
        SceneManager.LoadScene("MikeScene");
    }
    public void loadLevelFive()
    {
        SceneManager.LoadScene("Daniel Level 1");
    }
    public void loadLevelSix()
    {
        SceneManager.LoadScene("Daniel Level 2");
    }

}
