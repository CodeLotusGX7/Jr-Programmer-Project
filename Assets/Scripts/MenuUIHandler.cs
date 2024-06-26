using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.Instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;

        // ColorPicker.SelectColor(MainManager.Instance.TeamColor);

        // testing to see if I set something in the inspector
        try
        {
            ColorPicker.SelectColor(MainManager.Instance.TeamColor);
        }
        catch (NullReferenceException)
        {
            Debug.Log("myLight was not set in the inspector");
        }

    }

    // loads scene one of the index
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // exits the game
    public void Exit()
    {
        //  save the user�s last selected color when the application exits
        MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else     
        Application.Quit();
#endif  
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
        Debug.Log("saved color");
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
