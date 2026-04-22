using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketManager : MonoBehaviour
{
    public int startingRockets, currentRockets;
    public List<GameObject> rocketIcons; //tag all the UI images of rockets with RocketIcon

    void Start()
    {
        currentRockets = startingRockets;
        GameObject[] rocketIconsArray = GameObject.FindGameObjectsWithTag("RocketIcon");
        foreach (GameObject icon in rocketIconsArray)
        {
            rocketIcons.Add(icon);
        }
        rocketIcons.Sort(CompareXPosition);
    }

    void Update()
    {
        for (int i = 0; i < rocketIcons.Count; i++)
        {
            if (i < currentRockets)
            {
                rocketIcons[i].SetActive(true);
            }
            else
            {
                rocketIcons[i].SetActive(false);
            }
        }
    }

    public void RocketLaunched()
    {
        currentRockets--;
    }

    public void ResetRockets()
    {
        currentRockets = startingRockets;
    }

    private static int CompareXPosition(GameObject x, GameObject y)
    {
        return x.transform.position.x.CompareTo(y.transform.position.x);
    }
}