using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField] GameObject rpg;
    [SerializeField] GameObject RocketIcon1;
    [SerializeField] GameObject RocketIcon2;
    [SerializeField] GameObject RocketIcon3;
    [SerializeField] GameObject Reticle;
    [SerializeField] GameObject Objective;
    [SerializeField] GameObject Objectivecount;
    [SerializeField] GameObject playerScript;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        rpg.SetActive(true);
        playerScript.GetComponent<PlayerShoot>().enabled = true;  
        


    }
    


   

}
