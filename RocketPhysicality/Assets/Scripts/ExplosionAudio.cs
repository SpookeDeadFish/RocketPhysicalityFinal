using System.Collections;
using UnityEngine;

public class ExplosionAudio : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
