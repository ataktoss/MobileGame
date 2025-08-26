using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    // Call this from your UI Button
    public void FullRestart()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        // Make sure time is normal (in case the game was paused/slow-mo)
        Time.timeScale = 1f;

        // Optional: clear input, stop audio, etc.
        // AudioListener.pause = false;

        // 1) Destroy all objects in the DontDestroyOnLoad scene
        DestroyAllDontDestroyOnLoad();

        // 2) Reload the very first scene (index 0) or your bootstrap scene
        var op = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        // (Optional) show a loading spinner here
        while (!op.isDone)
            yield return null;
    }

    // Nukes the special DDOL scene so everything truly resets
    private static void DestroyAllDontDestroyOnLoad()
    {
        // Create a temp object inside DDOL scene so we can reference that scene
        var temp = new GameObject("__ddol_finder__");
        Object.DontDestroyOnLoad(temp);
        var ddolScene = temp.scene;

        // Collect root objects in DDOL scene
        var roots = ddolScene.GetRootGameObjects();

        // Destroy them all (except the temp, which we’ll also destroy)
        for (int i = 0; i < roots.Length; i++)
        {
            if (roots[i] != null)
                Object.Destroy(roots[i]);
        }
        // Just in case temp wasn’t in roots yet
        if (temp != null) Object.Destroy(temp);
    }
}
