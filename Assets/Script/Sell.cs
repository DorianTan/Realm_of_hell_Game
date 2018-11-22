using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using TMPro;

public class Sell : MonoBehaviour
{
    [SerializeField] private BuildManager buildManager;

    private int price;
    private int pricePre=0;
    public TextMeshProUGUI SellText;


    void DisplaySell()
    {
        SellText.text = "Sell" + "\n" +"$ "+ price;
    }

	// Update is called once per frame
	void Update ()
	{
	    if (buildManager._turret==null)
	    {
	        price = 0;
        }
	    else
	    {
             price =buildManager._turret.GetComponent<Turret>().SO_Turret.sell;
	         if (price != pricePre)
	         {
	             DisplaySell();
	             pricePre = price;
	         }
	    }

	    
    }

    public void Destroy()
    {
        Destroy(buildManager._turret);
        PlayerStat.Money += price;
        SellText.text = "Sell" + "\n";
    }
}
