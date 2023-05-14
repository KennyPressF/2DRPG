using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScripts :MonoBehaviour
{
    public static HelperScripts instance;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool FlipACoin()
    {
        // Generate a random number between 0 and 1
        float randomNum = Random.Range(0f, 1f);

        if (randomNum >= 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
