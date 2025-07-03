using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    float wait;

    private void Start()
    {
        wait = Time.fixedTime + 5f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime >= wait) //wait 5 seconds
        {
            int num = Random.Range(0, 100000000); //max a million
            if (num == 100000000)
            {
                Destroy(this); //1 in 1million chance to delete floor
            }

        }

    }
}
