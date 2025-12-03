using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;   // Stops play mode in Editor
#else
        Application.Quit();                                // Quits the built game
#endif
    }
}