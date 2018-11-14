using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public GameObject turret;

    [Header("Option")]
    BuildManager buildManager;

    public Vector3 positionOffset;

    

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

        if (!buildManager.CanBuild)
            return;
        
        if (turret != null)
        {
            Debug.Log("You can not build here! - TODO: Display on screnn. ");
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
