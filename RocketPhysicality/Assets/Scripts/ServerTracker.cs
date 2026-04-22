using UnityEngine;
using TMPro;

public class ServerTracker : MonoBehaviour
{
    public int serversTotal, serversDestroyed = 0;
    TMP_Text numberDisplay, winDisplay;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
        numberDisplay = GameObject.FindGameObjectWithTag("ServerCount").GetComponent<TMP_Text>();
        winDisplay = GameObject.FindGameObjectWithTag("WinText").GetComponent<TMP_Text>();
        winDisplay.enabled = false;
    }

    private void Update()
    {
        numberDisplay.text = serversDestroyed + "/" + serversTotal;
        if (serversDestroyed >= serversTotal * 2/3 & serversDestroyed != 0) //!=0 for handling int-math truncation (there is only one server in the tutorial)
        {
            winDisplay.enabled = true;
            sceneLoader.levelWon = true;
        }
    }

    public void incrementTotal()
    {
        serversTotal++;
    }

    public void incrementDestroyed()
    {
        serversDestroyed++;
    }
}
