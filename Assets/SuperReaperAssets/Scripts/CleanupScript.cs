using UnityEngine;
using System.Collections.Generic;

public class CleanupScript : MonoBehaviour {

    protected static List<GameObject> objectsToCleanup = new List<GameObject>();

    [SerializeField, Tooltip("the lowest allowed framerate before running cleanup automatically.")]
    private int minimumFramerate;

    void FixedUpdate () {
        if (QualitySettings.vSyncCount == 1)
        {
            minimumFramerate = Screen.currentResolution.refreshRate - 5;
        }
        else { minimumFramerate = 144; }
    }

    // Update is called once per frame
    void Update () {
        if (2 / Time.deltaTime <= minimumFramerate && Time.timeScale == 1)
        {
            DestroyObjects();
        }

        // Manual cleanup key for testing.
        if (Input.GetKeyUp("k") && Debug.isDebugBuild)
        {
            DestroyObjects();
        }
	}

    // Used for adding objects to the destruction list.
    public static void MarkObjectForCleanup(GameObject obj) {
        objectsToCleanup.Add(obj);
    }

    // Destroys every object that is marked for cleanup.
    public static void DestroyObjects () {
        Debug.Log(objectsToCleanup.Count);
        foreach (var GameObject in objectsToCleanup)
        {
            Destroy(GameObject);
        }
        objectsToCleanup.Clear();
    }
}
