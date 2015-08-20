﻿    using UnityEngine;

public class NavigationPrompt : MonoBehaviour 
{
    bool showDialog;

    void OnTriggerEnter2D(Collider2D col)
    {
        showDialog = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        showDialog = false;
    }

    void OnGUI()
    {
        if (showDialog)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
            GUI.Box(new Rect(0, 0, 300, 250), "");
            GUI.Label(new Rect(15, 10, 300, 68), "Do you want to travel?");
            if (GUI.Button(new Rect(55, 100, 180, 40), "Travel"))
            {
                showDialog = false;
                //Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(55, 150, 180, 40), "Nah~"))
            {
                showDialog = false;
            }
            GUI.EndGroup();

        }
    }
}