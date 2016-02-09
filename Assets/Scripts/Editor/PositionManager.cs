using UnityEngine;
using UnityEditor;

public class PositionManager : MonoBehaviour
{
    // Define a menu option in the editor to create the new asset
    [MenuItem("Assets/Create/PositionManager")]
    public static void CreateAsset()
    {
        // Create a new instance of our scriptable object
        ScriptingObject positionManager = ScriptableObject.CreateInstance<ScriptingObject>();

        // Create a .asset file for our new object and save it
        AssetDatabase.CreateAsset(positionManager, "assets/newPositionManager.asset");
        AssetDatabase.SaveAssets();

        // Now switch the inspector to our new object
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = positionManager;
    }
}
