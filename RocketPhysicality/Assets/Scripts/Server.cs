using UnityEngine;

public class Server : MonoBehaviour
{
    ServerTracker serverTracker;

    void Start()
    {
        serverTracker = FindFirstObjectByType<ServerTracker>();
        serverTracker.incrementTotal();
    }

    private void OnDisable()
    {
        serverTracker.incrementDestroyed();
    }
}
