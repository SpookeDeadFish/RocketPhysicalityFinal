using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class PlayerShoot : MonoBehaviour
{
    InputSystem_Actions inputActions;
    RocketManager rocketManager; //tracks how many rockets you have
    SceneLoader sceneLoader; //it was easiest to have this script track the "reset level" input
    bool shouldAim, aiming, ready, shouldFire, recovering, shouldReset;
    [SerializeField] public GameObject firePoint, directionGuide;
    [SerializeField] public GameObject projectilePrefab;
    public float speed = 20;
    CinemachineCamera cinemachineCamera; //for zooming effects
    public float zoomSpeedPerFrame = .2f;
    public float unZoomSpeedPerFrame = .5f;
    [SerializeField] AudioClip fireAudio, dryFireAudio;
    AudioSource audioPlayer;

    void Start()
    {
        inputActions = GetComponent<MovementInput>().inputActions;
        inputActions.Player.Attack.performed += ctx => shouldAim = true;
        inputActions.Player.Attack.canceled += ctx => shouldFire = true;

        rocketManager = FindFirstObjectByType<RocketManager>();
        sceneLoader = FindFirstObjectByType<SceneLoader>();
        cinemachineCamera = FindFirstObjectByType<CinemachineCamera>();

        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (shouldAim)
        {
            shouldAim = false;
            aiming = true;
            StartCoroutine(Aim());
        }

        if (shouldFire)
        {
            if (ready)
            {
                shouldFire = false;
                ready = false;
                recovering = true;
                StartCoroutine(UnAim());
                if (rocketManager.currentRockets > 0)
                {
                    Shoot();
                }
                else
                {
                    audioPlayer.PlayOneShot(dryFireAudio);
                }
            }
            else
            {
                aiming = false;
                shouldFire = false;
            }
        }

        if (inputActions.Player.Reset.triggered)
        {
            sceneLoader.ReloadLevel();
        }
    }

    IEnumerator Aim()
    {
        while (aiming)
        {
            if (cinemachineCamera.Lens.FieldOfView > 40)
            {
                cinemachineCamera.Lens.FieldOfView -= zoomSpeedPerFrame;
                yield return null;
            }
            else
            {
                aiming = false;
                ready = true;
                StopCoroutine(Aim());
                yield return null;
            }
        }
        if (!ready)
        {
            recovering = true;
            StartCoroutine(UnAim());
        }
        yield return null;
    }
    
    public void Shoot()
    {
        rocketManager.RocketLaunched();

        audioPlayer.PlayOneShot(fireAudio, .5f);
        
        GameObject projectile = Instantiate(projectilePrefab, firePoint.transform.position, directionGuide.transform.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.transform.forward * speed, ForceMode.Impulse);
        }
       
        Destroy(projectile, 3f);
    }

    IEnumerator UnAim()
    {
        while (recovering)
        {
            if (cinemachineCamera.Lens.FieldOfView < 60)
            {
                cinemachineCamera.Lens.FieldOfView += unZoomSpeedPerFrame;
                yield return null;
            }
            else
            {
                recovering = false;
                StopCoroutine(UnAim());
                yield return null;
            }
        }
        yield return null;
    }
}

