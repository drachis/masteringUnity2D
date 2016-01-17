using UnityEngine;
using System.Collections;

public class NavigationPrompt : MonoBehaviour {

    bool showDialog;

    Vector2 ratio = new Vector2((float)Screen.width/800, (float)Screen.height/600);
    GUIStyle fontStyle;
    public int fScale = 30;
    void Start()
    {

        fontStyle = new GUIStyle();
        fontStyle.fontSize = fScale * Screen.width/800;
        fontStyle.normal.textColor = Color.gray;
    }
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
            GUI.BeginGroup(new Rect(Screen.width / 2 - 150*ratio.x, 50*ratio.y, 300*ratio.x, 250*ratio.y));

            GUI.Box(new Rect(0, 0, 300*ratio.x, 200*ratio.y), "");

            GUI.Label(new Rect(15*ratio.x, 10*ratio.y, 300*ratio.x, 68*ratio.y), "Do you want to travel\nto the " + this.tag + " ?", fontStyle);

            if ( GUI.Button(new Rect(55*ratio.x, 100*ratio.y, 180*ratio.x, 40*ratio.y), "Travel", fontStyle))
            {
                showDialog = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(this.tag);
            }

            if (GUI.Button(new Rect(55*ratio.x, 150*ratio.y, 180*ratio.x, 40*ratio.y), "Stay", fontStyle))
            {
                showDialog = false;
            }

            GUI.EndGroup();
        }
    }
}
