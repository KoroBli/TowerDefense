using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{
    public TurretBlueprintBehaviour standardTurret;
    public TurretBlueprintBehaviour missileTurret;
    public TurretBlueprintBehaviour laserTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
