using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // start() and update() methods deleted. Not needed

   
    // data persistence
    // allows you to access the MainManager object from any other script
    
    // class member declaration ( static = values stored ->
    // shared by all instances of class. 1 for all
    public static MainManager Instance;

    public Color TeamColor;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
