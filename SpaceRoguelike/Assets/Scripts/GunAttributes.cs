using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for sprite selection and gun generation
// Default must always be at position 0 and NumberOfMemebers must
//      always be at the last position.
public enum GunType
{
    Default,
    Pistol,
    SMG,
    AR,
    Rifle,
    Shotgun,
    Launcher,
    NumberOfMembers
}

// Class to be composed into any weapon object.
// Represents sheet of key weapon characteristics
public class GunAttibuteSheet
{
    // Default Assignments
    public float spread = 10.0f;
    public int fireRate = 10;
    public int reloadTime = 100;
    public float damage = 10.0f;
    public float recoil = 10.0f;
    public float muzzleVelocity = 10.0f;
    public GunType weaponType = GunType.Pistol;
    public int level = 1;

    public Sprite projectileSprite;
    public Sprite worldSprite;

    // Gun generation constraints

    const float splashRadiusNone = 0.0f;

    const float minSpreadPistol = 5.0f;
    const float maxSpreadPistol = 30.0f;
    const int minFireRatePistol = 3;
    const int maxFireRatePistol = 10;
    const int minReloadTimePistol = 3;
    const int maxReloadTimePistol = 10;
    const float minDamagePistol = 5.0f;
    const float maxDamagePistol = 10.0f;
    const float minRecoilPistol = 1.0f;
    const float maxRecoilPistol = 1.5f;
    const float minMuzzleVelocityPistol = 10.0f;
    const float maxMuzzleVelocityPistol = 15.0f;
    const bool splashPistol = false;

    const float minSpreadSMG = 5.0f;
    const float maxSpreadSMG = 30.0f;
    const int minFireRateSMG = 3;
    const int maxFireRateSMG = 10;
    const int minReloadTimeSMG = 3;
    const int maxReloadTimeSMG = 10;
    const float minDamageSMG = 5.0f;
    const float maxDamageSMG = 10.0f;
    const float minRecoilSMG = 1.0f;
    const float maxRecoilSMG = 1.5f;
    const float minMuzzleVelocitySMG = 10.0f;
    const float maxMuzzleVelocitySMG = 15.0f;
    const bool splashSMG = false;

    const float minSpreadAR = 5.0f;
    const float maxSpreadAR = 30.0f;
    const int minFireRateAR = 3;
    const int maxFireRateAR = 10;
    const int minReloadTimeAR = 3;
    const int maxReloadTimeAR = 10;
    const float minDamageAR = 5.0f;
    const float maxDamageAR = 10.0f;
    const float minRecoilAR = 1.0f;
    const float maxRecoilAR = 1.5f;
    const float minMuzzleVelocityAR = 10.0f;
    const float maxMuzzleVelocityAR = 15.0f;
    const bool splashAR = false;

    const float minSpreadRifle = 5.0f;
    const float maxSpreadRifle = 30.0f;
    const int minFireRateRifle = 3;
    const int maxFireRateRifle = 10;
    const int minReloadTimeRifle = 3;
    const int maxReloadTimeRifle = 10;
    const float minDamageRifle = 5.0f;
    const float maxDamageRifle = 10.0f;
    const float minRecoilRifle = 1.0f;
    const float maxRecoilRifle = 1.5f;
    const float minMuzzleVelocityRifle = 10.0f;
    const float maxMuzzleVelocityRifle = 15.0f;
    const bool splashRifle = false;

    const float minSpreadShotgun = 5.0f;
    const float maxSpreadShotgun = 30.0f;
    const int minFireRateShotgun = 3;
    const int maxFireRateShotgun = 10;
    const int minReloadTimeShotgun = 3;
    const int maxReloadTimeShotgun = 10;
    const float minDamageShotgun = 5.0f;
    const float maxDamageShotgun = 10.0f;
    const float minRecoilShotgun = 1.0f;
    const float maxRecoilShotgun = 1.5f;
    const float minMuzzleVelocityShotgun = 10.0f;
    const float maxMuzzleVelocityShotgun = 15.0f;
    const bool splashShotgun = false;

    const float minSpreadLauncher = 5.0f;
    const float maxSpreadLauncher = 30.0f;
    const int minFireRateLauncher = 3;
    const int maxFireRateLauncher = 10;
    const int minReloadTimeLauncher = 3;
    const int maxReloadTimeLauncher = 10;
    const float minDamageLauncher = 5.0f;
    const float maxDamageLauncher = 10.0f;
    const float minRecoilLauncher = 1.0f;
    const float maxRecoilLauncher = 1.5f;
    const float minMuzzleVelocityLauncher = 10.0f;
    const float maxMuzzleVelocityLauncher = 15.0f;
    const bool splashLauncher = true;
    const float minSplashRadiusLauncher = 0.5f;
    const float maxSplashRadiusLauncher = 3.0f;

    public void GenerateRandom()
    {
        // Pick weapon type
        weaponType = intToGunType(UnityEngine.Random.Range(1, (int)GunType.NumberOfMembers - 1));

        // TODO: Implement level scaling
        // Fetch player level here

        // Generate Stats
        spread = GenerateGunSpread(weaponType);
        fireRate = GenerateGunFireRate(weaponType);
        reloadTime = GenerateGunReloadTime(weaponType);
        damage = GenerateGunDamage(weaponType);
        recoil = GenerateGunRecoil(weaponType);
        muzzleVelocity = GenerateGunMuzzleVelocity(weaponType);

    }

    private GunType intToGunType(int inp)
    {
        switch(inp)
        {
            case 1:
                return GunType.Pistol;
            case 2:
                return GunType.SMG;
            case 3:
                return GunType.AR;
            case 4:
                return GunType.Rifle;
            case 5:
                return GunType.Shotgun;
            case 6:
                return GunType.Launcher;
            default:
                return GunType.Pistol;
        }
    }

    private float GenerateGunSpread(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minSpreadPistol, maxSpreadPistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minSpreadSMG, maxSpreadSMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minSpreadAR, maxSpreadAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minSpreadRifle, maxSpreadRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minSpreadShotgun, maxSpreadPistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minSpreadLauncher, maxSpreadLauncher);
            default:
                return 0.0f;
        }
    }

    private int GenerateGunFireRate(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minFireRatePistol, maxFireRatePistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minFireRateSMG, maxFireRateSMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minFireRateAR, maxFireRateAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minFireRateRifle, maxFireRateRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minFireRateShotgun, maxFireRatePistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minFireRateLauncher, maxFireRateLauncher);
            default:
                return 1;
        }
    }

    private int GenerateGunReloadTime(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minReloadTimePistol, maxReloadTimePistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minReloadTimeSMG, maxReloadTimeSMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minReloadTimeAR, maxReloadTimeAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minReloadTimeRifle, maxReloadTimeRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minReloadTimeShotgun, maxReloadTimePistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minReloadTimeLauncher, maxReloadTimeLauncher);
            default:
                return 1;
        }
    }

    private float GenerateGunDamage(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minDamagePistol, maxDamagePistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minDamageSMG, maxDamageSMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minDamageAR, maxDamageAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minDamageRifle, maxDamageRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minDamageShotgun, maxDamagePistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minDamageLauncher, maxDamageLauncher);
            default:
                return 1;
        }
    }

    private float GenerateGunRecoil(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minRecoilPistol, maxRecoilPistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minRecoilSMG, maxRecoilSMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minRecoilAR, maxRecoilAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minRecoilRifle, maxRecoilRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minRecoilShotgun, maxRecoilPistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minRecoilLauncher, maxRecoilLauncher);
            default:
                return 1;
        }
    }

    private float GenerateGunMuzzleVelocity(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minMuzzleVelocityPistol, maxMuzzleVelocityPistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minMuzzleVelocitySMG, maxMuzzleVelocitySMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minMuzzleVelocityAR, maxMuzzleVelocityAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minMuzzleVelocityRifle, maxMuzzleVelocityRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minMuzzleVelocityShotgun, maxMuzzleVelocityPistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minMuzzleVelocityLauncher, maxMuzzleVelocityLauncher);
            default:
                return 1;
        }
    }

    private bool GenerateGunSplashBool(GunType t)
    {
        switch(t)
        {
            case GunType.Pistol:
                return splashPistol;
            case GunType.SMG:
                return splashSMG;
            case GunType.AR:
                return splashAR;
            case GunType.Rifle:
                return splashRifle;
            case GunType.Shotgun:
                return splashShotgun;
            case GunType.Launcher:
                return splashLauncher;
            default:
                return false;
        }
    }

    private float GenerateGunSplashRadius(GunType t)
    {
        switch (t)
        {
            case GunType.Pistol:
                return UnityEngine.Random.Range(minMuzzleVelocityPistol, maxMuzzleVelocityPistol);
            case GunType.SMG:
                return UnityEngine.Random.Range(minMuzzleVelocitySMG, maxMuzzleVelocitySMG);
            case GunType.AR:
                return UnityEngine.Random.Range(minMuzzleVelocityAR, maxMuzzleVelocityAR);
            case GunType.Rifle:
                return UnityEngine.Random.Range(minMuzzleVelocityRifle, maxMuzzleVelocityRifle);
            case GunType.Shotgun:
                return UnityEngine.Random.Range(minMuzzleVelocityShotgun, maxMuzzleVelocityPistol);
            case GunType.Launcher:
                return UnityEngine.Random.Range(minMuzzleVelocityLauncher, maxMuzzleVelocityLauncher);
            default:
                return 1;
        }
    }
}

public class GunAttributes : MonoBehaviour {

    List<GunAttibuteSheet> Guns;

	// Use this for initialization
	void Start ()
    {
        Guns = new List<GunAttibuteSheet>();
        Guns.Add(new GunAttibuteSheet());
        Guns[0].GenerateRandom();
        Debug.Log("Guns[0] type = " + Guns[0].weaponType);
	}
	
    void Initialize ()
    {

    }

	// Update is called once per frame
	void Update ()
    {
		
	}

    void AddWeapon ()
    {

    }

}
