using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;
    // Reference to BuildManager
    public static BuildManager instance;

    // Singleton process to keep one BuildManager 
    void Awake()
    {
        if(instance != null)
        {
            UnityEngine.Debug.Log("BuildManager is alcready created!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject secondTurretPrefab;

    void Start()
    {
        turretToBuild = standardTurretPrefab;
    }



    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
