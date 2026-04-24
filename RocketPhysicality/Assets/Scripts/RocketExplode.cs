using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;

public class RocketExplode : MonoBehaviour
{
    [SerializeField] GameObject explosionCenter;
    Vector3 explosionPosition;
    [SerializeField] float radius, power, upMod;
    [SerializeField] public GameObject sparks, soundPrefab;
    private bool done = true;
    [SerializeField] CinemachineCamera cinemachineCamera;
    [SerializeField] CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    void Awake()
    {
        cinemachineCamera = FindFirstObjectByType<CinemachineCamera>();
        cinemachineBasicMultiChannelPerlin = FindFirstObjectByType<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            explosionPosition = explosionCenter.transform.position;

            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        Instantiate(soundPrefab, transform.position, transform.rotation); //play explosion sound from an object that's not about to be removed
        StartCoroutine(ShakeCamera(7f, 1f)); //shake cam
        
        yield return new WaitForSeconds(.2f);

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag != "Player" & hit.gameObject.tag != "Projectile")
            {
                Debug.Log(hit.gameObject);
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    //StartCoroutine(explosion2(rb));
                    ; rb.AddExplosionForce(power, explosionPosition, radius, upMod);
                    
                }
                if (done == true)
                {
                    Instantiate(sparks, transform.position, Random.rotation);
                    done = false;
                }
            }
        }
        cinemachineBasicMultiChannelPerlin.AmplitudeGain = 0f;
        Destroy(this.gameObject);
    }


    public IEnumerator ShakeCamera(float intensity, float time)
    {
        float shakeTime = time;
        while (shakeTime > 0f)
        {
            shakeTime -= Time.deltaTime;
            cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;
            yield return null;
        }
        cinemachineBasicMultiChannelPerlin.AmplitudeGain = 0f;
        yield break;
    }
}
