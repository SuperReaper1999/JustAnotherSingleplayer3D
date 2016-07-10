using UnityEngine;
using System.Collections;

public class RemovalTimer : MonoBehaviour {

    [SerializeField, Tooltip("Ammount of time until removal in seconds.")]
    private float removalTime;

    [SerializeField, Tooltip("Ammount of time until being added to cleanup script.")]
    private float cleanupTime;

    private bool isMarked = false;

    // Update is called once per frame
    void Update () {
        removalTime -= Time.deltaTime;
        cleanupTime -= Time.deltaTime;
        if (removalTime <= 0)
        {
            Destroy(this.gameObject);
        }

        if (cleanupTime <= 0 && !isMarked)
        {
            isMarked = true;
            Debug.Log("Marked object for cleanup");
            CleanupScript.MarkObjectForCleanup(this.gameObject);
        }
    }
}
