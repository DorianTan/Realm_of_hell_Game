using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject _turret;

    void Awake()
    {
        if (instance!=null)
        {
            return;
        }
        instance = this;
    }

    public GameObject DemonTurretPrefab;
    public GameObject GorgonTurretPrefab;
    public GameObject GoblinTurretPrefab;
    public GameObject SkeletonTurretPrefab;

    private So_Turret turretToBuild;

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
        turret.GetComponent<Turret>().SO_Turret = turretToBuild;
        node.turret = turret;
        Debug.Log("Turret Build. Money left"+ PlayerStat.Money);
    }

    public void SelectNode(Node node)
    {
        turretToBuild = null;
        _turret = node.turret;  //pour savoir qu'elle tourelle est selectionner


    }

    public void SelectTurretToBuild(So_Turret turret)
    {
        turretToBuild = turret;
    }
}
