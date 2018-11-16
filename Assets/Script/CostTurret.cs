using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostTurret : MonoBehaviour {

    private TextMeshProUGUI CostText;
    [SerializeField]
    private So_Turret scriptableObject;

    // Update is called once per frame
    void Start ()
    {
        CostText = GetComponent<TextMeshProUGUI>();
        CostText.text ="$"+ scriptableObject.cost.ToString();
    }
}
