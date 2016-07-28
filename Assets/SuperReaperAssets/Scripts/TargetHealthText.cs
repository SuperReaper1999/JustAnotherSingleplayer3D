using UnityEngine;
using System.Collections;

public class TargetHealthText : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = transform.root.GetComponent<Health>().GetCurrentHealth().ToString();
        transform.parent.LookAt(Camera.main.transform);
    }
}
