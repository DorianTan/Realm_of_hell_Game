using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public So_Turret DemonTurret;
    public So_Turret GorgonTurret;
    public So_Turret GoblinTurret;
    public So_Turret SkeletonTurret;
    public GameObject InfoDemon;
    public GameObject InfoGorgon;
    public GameObject InfoGoblin;
    public GameObject InfoSkeleton;
    private GameObject InfoActive;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void SelectDemon()
	{
	    Debug.Log("Demon Purchase");
        buildManager.SelectTurretToBuild(DemonTurret);
	    InfoSkeleton.SetActive(false);
	    InfoGorgon.SetActive(false);
	    InfoGoblin.SetActive(false);
        InfoDemon.SetActive(true);
	}
    public void SelectGorgon()
    {
        Debug.Log("Gorgon Purchase");
        buildManager.SelectTurretToBuild(GorgonTurret);
        InfoDemon.SetActive(false);
        InfoSkeleton.SetActive(false);
        InfoGoblin.SetActive(false);
        InfoGorgon.SetActive(true);
    }
    public void SelectGoblin()
    {
        Debug.Log("Goblin Purchase");
        buildManager.SelectTurretToBuild(GoblinTurret);
        InfoDemon.SetActive(false);
        InfoSkeleton.SetActive(false);
        InfoGorgon.SetActive(false);
        InfoGoblin.SetActive(true);
    }
    public void SelectSkeleton()
    {
        Debug.Log("Skeleton Purchase");
        buildManager.SelectTurretToBuild(SkeletonTurret);
        InfoDemon.SetActive(false);
        InfoGoblin.SetActive(false);
        InfoGorgon.SetActive(false);
        InfoSkeleton.SetActive(true);
    }
}
