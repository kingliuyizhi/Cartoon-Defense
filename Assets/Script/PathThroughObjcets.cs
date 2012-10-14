using UnityEngine;
using System.Collections;

public class PathThroughObjcets : MonoBehaviour 
{
	
	public GameObject[] pathPoints;
	private int	currentPathIndex = 0;
	public float speed = 1.0f;
	//public float goalSize = 0.1f;
	private Vector3 movementDirection;
	
	
	// Use this for initialization
	void Start () 
	{
		
		//transform.position //Where we are
		//pathPoints[0].position //Where we are going
		movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//movement code
		transform.position += movementDirection*speed*Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == pathPoints[currentPathIndex].name)
		{
			transform.position = pathPoints[currentPathIndex].transform.position;
			currentPathIndex++;
			if(currentPathIndex >= pathPoints.Length)
			{
				//The Enemy go to player's base
				BasicEnemy.EnemyDestroyType = 0;
				Destroy(gameObject);
				PlayerLifeManager.playerLife--;
			}
			else
			{
				movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;
		
			}
		}
	}
	
	void SetPathPoints(GameObject[] inputPathPoints)
	{
		pathPoints = inputPathPoints;
	}
}
