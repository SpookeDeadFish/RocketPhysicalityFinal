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
        SceneManager.LoadScene("LukeScnee");
    }
    public void loadLevelTwo()
    {
        SceneManager.LoadScene("MikeScene");
    }
}
