using UnityEngine;
using System.Collections;

public class GunAmmoHandler : MonoBehaviour {

    [SerializeField]
    private int currentRifleAmmo;
    [SerializeField]
    private int currentPistolAmmo;
    [SerializeField]
    private int currentLauncherAmmo;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public int GetRifleAmmo() { return currentRifleAmmo; }
    public int GetPistolAmmo() { return currentPistolAmmo; }
    public int GetLauncherAmmo() { return currentLauncherAmmo; }

    public void SetRifleAmmo(int ammoValue) {
        if (currentRifleAmmo + ammoValue < 0)
        {
            currentRifleAmmo = 0;
            return;
        }
        currentRifleAmmo += ammoValue;
    }

    public void SetPistolAmmo(int ammoValue) {
        if (currentPistolAmmo + ammoValue < 0)
        {
            currentPistolAmmo = 0;
            return;
        }
        currentPistolAmmo += ammoValue;
    }

    public void SetLauncherAmmo(int ammoValue) {
        if (currentLauncherAmmo + ammoValue < 0)
        {
            currentLauncherAmmo = 0;
            return;
        }
        currentLauncherAmmo += ammoValue;
    }
}
