using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public So_Turret DemonTurret;
    public So_Turret GorgonTurret;
    public So_Turret GoblinTurret;
    public So_Turret SkeletonTurret;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void SelectDemon()
	{
	    Debug.Log("Demon Purchase");
        buildManager.SelectTurretToBuild(DemonTurret);
	}
    public void SelectGorgon()
    {
        Debug.Log("Gorgon Purchase");
        buildManager.SelectTurretToBuild(GorgonTurret);
    }
    public void SelectGoblin()
    {
        Debug.Log("Goblin Purchase");
        buildManager.SelectTurretToBuild(GoblinTurret);
    }
    public void SelectSkeleton()
    {
        Debug.Log("Skeleton Purchase");
        buildManager.SelectTurretToBuild(SkeletonTurret);
    }
}
