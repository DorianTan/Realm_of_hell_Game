using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="Turret", order = 1)]
public class So_Turret : ScriptableObject
{
    public GameObject prefab;

    public int cost;
    public int sell;
    public int Damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
