using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool levelWon;
    static int sceneIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (levelWon)
        {
            StartCoroutine(LoadNextLevel());
            levelWon = false;
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(5);
        /*sceneIndex++;
        Debug.Log(SceneUtility.GetScenePathByBuildIndex(sceneIndex));
        if (SceneUtility.GetScenePathByBuildIndex(sceneIndex).ToString() != "")
        {
            SceneManager.LoadScene(sceneIndex);
        }*/
        SceneManager.LoadScene("Title Scene");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
