using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int totalScenesChanged = 0; //feed this into the WakeUp UI scene - you played through x amount of scenes


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene()
    {
        int amountOfScenes = 3; // total amount of scenes
        int num = Random.Range(1, amountOfScenes); // don't include menus and game end scenes

        if (num >= amountOfScenes || num < 1) //if smaller or larger than amounnt of scenes allowed, repick
        {
            num = Random.Range(1, amountOfScenes);
        }
        else
        { 
            SceneManager.LoadScene(num);
            totalScenesChanged = totalScenesChanged + 1;
        }
    }

    public void WakeUp()
    {
        SceneManager.LoadScene("WakeUp"); //wake up scene
        totalScenesChanged = totalScenesChanged + 1;
    }

}
