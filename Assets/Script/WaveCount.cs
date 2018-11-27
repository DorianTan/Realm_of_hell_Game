using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveCount : MonoBehaviour
{

    public TextMeshProUGUI CountWave;

	// Update is called once per frame
	void Update () {

        CountWave.text = PlayerStat.Rounds.ToString();
	}
}
