using System.Collections;
using UnityEngine;

public class RocketExplode : MonoBehaviour
{
    [SerializeField] GameObject explosionCenter;
    Vector3 explosionPosition;
    [SerializeField] float radius, power, upMod;
    [SerializeField] public GameObject sparks, soundPrefab;
    private bool done = true;

    void Start()
    {
        
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

        yield return new WaitForSeconds(.1f);

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
        
        Destroy(this.gameObject);
    }
}
