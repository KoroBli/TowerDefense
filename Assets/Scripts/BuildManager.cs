using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("More than on intance in scene!");
            return;
        }

        Instance = this;
    }

    public GameObject buildEffect;

    private TurretBlueprintBehaviour turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(NodeBehaviour node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBlueprintBehaviour turret)
    {
        turretToBuild = turret;
    }
}
