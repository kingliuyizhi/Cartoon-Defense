using UnityEngine;
using System.Collections;

public class BonusManager: MonoBehaviour 
{
	public int initialBonus = 50;
	public GameObject bonusDisplay;
	
	public static int bonus;

	// Use this for initialization
	void Start () 
	{
		bonus = initialBonus;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		bonusDisplay.GetComponent<TextMesh>().text = "Bonus:"+bonus.ToString();	
	}
}
