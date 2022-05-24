using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    public static SceneReload instance;
    private bool readyToReload;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        readyToReload = false;
    }

    void Update()
    {
        if(Input.anyKey && readyToReload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }   

    public bool ReadyToReload
    {
        get
        {
            return readyToReload;
        }
        set
        {
            readyToReload = value;
        }
    }
}
