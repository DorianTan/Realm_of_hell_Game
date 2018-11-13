using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turret;

    BuildManager buildManager;

    

	// Use this for initialization
	void Start ()
	{
	   buildManager = BuildManager.instance;
	}

   

    void OnMouseDown()
    {

        if (buildManager.GetTurretToBuild()==null)
            return;
        
        if (turret != null)
        {
            Debug.Log("Tu ne peux pas construir ici! - TODO: Display on screnn. ");
            return;

        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
    }
}
