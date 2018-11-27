using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    public Vector3 positionOffset;
    public GameObject turret;

	// Use this for initialization
	void Start ()
	{
	   buildManager = BuildManager.instance;
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
 
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;

        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        buildManager.BuildTurretOn(this);
    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
            
    }
}
