using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public int initialLevel = 1;
	public GameObject levelDisplay;
	
	public static int level;

	// Use this for initialization
	void Start () 
	{
		level = initialLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		levelDisplay.GetComponent<TextMesh>().text = "Level:"+level.ToString();
	}
}
