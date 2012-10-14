using UnityEngine;
using System.Collections;

public class PlayerLifeManager : MonoBehaviour 
{
	public int initialPlayerLife = 20;
	public static int playerLife;
	public GameObject playerLifeDisplay;
	
	// Use this for initialization
	void Start () 
	{
		playerLife = initialPlayerLife ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerLifeDisplay.GetComponent<TextMesh>().text = "Life:"+playerLife.ToString();
		if(playerLife <= 0)
		{
			Application.LoadLevel("GameOver");
		}
	}
}
