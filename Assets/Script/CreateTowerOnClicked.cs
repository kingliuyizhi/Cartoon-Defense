using UnityEngine;
using System.Collections;

public class CreateTowerOnClicked : MonoBehaviour 
{
	//public GameObject tower;
	public TowerSelector towerSelector;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Clicked(Vector3 position)
	{
		if(BonusManager.bonus >= towerSelector.getSelectedTowerCost())
		{
			GameObject tower = towerSelector.GetSelectedTower();
			Instantiate(tower, position + Vector3.up*0.5f, tower.transform.rotation);
			BonusManager.bonus -= towerSelector.getSelectedTowerCost();
		}
	}
}
