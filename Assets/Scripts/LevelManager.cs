using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public string interfaceScene;
    public string defaultScene;

    public static LevelManager Instance {
        get; private set;
            }
	void Start () {
	
	}

    public void LoadLevel(string levelName) {
        int sceneCount = SceneManager.sceneCount;
        if (sceneCount >= 2)
        {
            Scene[] scenes = SceneManager.GetAllScenes();
            for (int i = 0; i < sceneCount; i++)
            {
                if( scenes[i].name != interfaceScene )
                {
                    SceneManager.UnloadScene(scenes[i].name);
                }
            }
        }
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
    }
	// Update is called once per frame
	void Awake () {
        LoadLevel(defaultScene);
	}
}
