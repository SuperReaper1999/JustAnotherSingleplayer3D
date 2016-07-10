using UnityEngine;
using System.Collections.Generic;

public class CleanupScript : MonoBehaviour {

    protected static List<GameObject> objectsToCleanup = new List<GameObject>();

    [SerializeField, Tooltip("the lowest allowed framerate before running cleanup automatically.")]
    private int minimumFramerate;

    // TODO : Fix this script running if v-sync is enabled and the refresh rate of the screen is lower than the minimum framerate Likely way to fix it will be to set minimum framerate to refreshrate of the monitor if v-sync is enabled.

    // Update is called once per frame
    void Update () {
        if (2 / Time.deltaTime <= minimumFramerate && Time.timeScale == 1)
        {
            Debug.Log("framerate is below " + minimumFramerate + " running cleanup." + "framerate was " + 2/Time.deltaTime + " when this was ran");
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
