using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money_UI : MonoBehaviour
{

    public TextMeshProUGUI WalletText;
	
	// Update is called once per frame
	public void DisplayMoney ()
	{
	    WalletText.text = "$" + PlayerStat.Money.ToString();
	}
}
