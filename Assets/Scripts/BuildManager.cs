
using System.Diagnostics;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
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
    public GameObject missileLauncherPrefab;

    public bool CanBuild {  get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            UnityEngine.Debug.Log("Not enough Money!");
            return ;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        UnityEngine.Debug.Log("Turret Built: Money Left" + PlayerStats.Money);
    }
}
