using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private static int money;    
    [SerializeField] public GameObject moneyCount;

    private int moneyPre;

    public static int Rounds;
    public static int Lives;
    public int startMoney = 400;
    public int startLives = 20;
    
    public static int Money
    {
        get { return money;}
        set
        {
            money = value;  
        }
    }

	// Use this for initialization
	void Start ()
	{
	    Money = startMoney;
        Lives = startLives;
	}
	
	// Update is called once per frame
	void Update () {
	    if (money != moneyPre)
	    {
            moneyCount.GetComponent<Money_UI>().DisplayMoney();
	        moneyPre = money;
	    }
	}
}
