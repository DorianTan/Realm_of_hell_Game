using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {

        if (instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject DemonTurretPrefab;
    public GameObject GorgonTurretPrefab;
    public GameObject GoblinTurretPrefab;
    public GameObject SkeletonTurretPrefab;

    private So_Turret turretToBuild;
    private Node selectedNode;
    public SelectUi selectUI;

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStat.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build");
            return;
        }

        PlayerStat.Money -= turretToBuild.cost;


        GameObject turret =(GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Build. Money left"+ PlayerStat.Money);
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;

        selectUI.SetTarget(node);
    }
    public void SelectTurretToBuild(So_Turret turret)
    {
        turretToBuild = turret;
        selectedNode = null;
    }
}
