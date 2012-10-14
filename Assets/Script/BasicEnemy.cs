using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour 
{
	
	public int life = 10;
	public static int EnemyDestroyType = 0;
	//public GameObject LifeBar;
	// Use this for initialization
	void Start () 
	{
		//GameObject lifeBar = Instantiate(LifeBar, transform.position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
		
	//When bullet hits enemy
	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Bullet")
		{
			life--;
			//Destroy(gameObject.GetComponentInChildren(EnemyLifeBar));
			Destroy(collision.collider.gameObject);
		}
		
		if(life <= 0)
		{
			Destroy(collision.collider.gameObject);
			EnemyDestroyType = 1; 
			Destroy(gameObject);
		}
	}
}
