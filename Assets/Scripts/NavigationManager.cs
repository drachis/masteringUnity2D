﻿using UnityEngine;
using System.Collections.Generic;

public class NavigationManager : MonoBehaviour
{
    private bool _CanNavigate;

    public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>()
    {
        {"World", "The big wild world." },
        {"Cave", "The deep dark cave." },
        {"City", "The bustling city" },
        {"Dungeon", "The deep dark dungeon" },
        {"Lair", "The hoard of your treasures" },
        {"Forest", "A lovely wooded glen." },        
    };

    public static string GetRouteInfo(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
    }
     public static bool CanNavigate(string destination)
    {
        return true;
    }
    public static void NavigateTo(string destination)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(destination);
        //Application.LoadLevel(destination); // this is obsolete. 
    }
}
