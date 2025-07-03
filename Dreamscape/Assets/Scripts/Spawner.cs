using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // for each dark or light tagged objects spawn these assets
    [SerializeField] GameObject[] DarkObjects;
    [SerializeField] GameObject[] LightObjects;
    [SerializeField] GameObject spawner;
   
    private void Start()
    {
        if (gameObject.tag == "DarkSpawn")
        {
            SpawnDarkObjects();
        }
        else if(gameObject.tag == "LightSpawn")
        {
            SpawnLightObjects();
        }
    }


    private void SpawnDarkObjects()
    {
        int randomNum = Random.Range(0, DarkObjects.Length);
        Instantiate(DarkObjects[randomNum], transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));
    }

    private void SpawnLightObjects()
    {
        int randomNum = Random.Range(0, LightObjects.Length);
        Instantiate(LightObjects[randomNum], transform.position, Quaternion.identity);
    }
}
