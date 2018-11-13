using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

	public void PurchaseDemon()
	{
	    Debug.Log("Demon Purchase");
        buildManager.SetTurretToBuild(buildManager.DemonTurretPrefab);
	}
    public void PurchaseGorgon()
    {
        Debug.Log("Gorgon Purchase");
        buildManager.SetTurretToBuild(buildManager.GorgonTurretPrefab);
    }
    public void PurchaseGoblin()
    {
        Debug.Log("Goblin Purchase");
        buildManager.SetTurretToBuild(buildManager.GoblinTurretPrefab);
    }
}
