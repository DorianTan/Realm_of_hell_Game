using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint DemonTurret;
    public TurretBlueprint GorgonTurret;
    public TurretBlueprint GoblinTurret;


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
}
