using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject[] pathPoints;
	
	public GameObject[] spawnList;
	

	
	public GameObject graphicalPathObject;
	
	public float spawnTime;
	
	private int spawnIndex = 0;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("Spawn",0.0f,spawnTime);
		CreateGraphicalPathObjects();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void Spawn()
	{
		//Spawn next enemy in spawnlist
		GameObject reference = Instantiate(spawnList[spawnIndex++], transform.position, Quaternion.identity) as GameObject;
		LevelManager.level = (spawnIndex / 5) + 1;
		
		//Set enemy path information
		reference.SendMessage("SetPathPoints", pathPoints);
	}
	
	void CreateGraphicalPathObjects()
	{
		//Create obejct and path between transform.position and first waypoint
		Vector3 pathObjectPosition = ((pathPoints[0].transform.position - transform.position) * 0.5f) + transform.position - Vector3.up*0.4f;
		Quaternion pathObjectOrientation = Quaternion.LookRotation(pathPoints[0].transform.position - transform.position);
		GameObject pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
		Vector3 newScale = Vector3.one;
		newScale.z = (pathPoints[0].transform.position - transform.position).magnitude;
		pathObject.transform.localScale = newScale;
		
		Vector2 newTextureScale = Vector2.one;
		newTextureScale.y = (pathPoints[0].transform.position - transform.position).magnitude;
		pathObject.renderer.material.mainTextureScale = newTextureScale;
		
		
		//Create the remain paths
		for(int i = 1; i < pathPoints.Length; i++)
		{
			pathObjectPosition = ((pathPoints[i].transform.position - pathPoints[i-1].transform.position) * 0.5f) + pathPoints[i-1].transform.position - Vector3.up*0.4f;
			pathObjectOrientation = Quaternion.LookRotation(pathPoints[i].transform.position - pathPoints[i-1].transform.position);
			pathObject = Instantiate(graphicalPathObject, pathObjectPosition, pathObjectOrientation) as GameObject;
			newScale = Vector3.one;
			newScale.z = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
			pathObject.transform.localScale = newScale;
		
			newTextureScale = Vector2.one;
			newTextureScale.y = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
			pathObject.renderer.material.mainTextureScale = newTextureScale;
			
		}
	}
	
		//Draw a line beforehand to show the routine
		void OnDrawGizmos()
		{
			Gizmos.DrawLine(transform.position, pathPoints[0].transform.position);
			for(int i=1; i< pathPoints.Length; i++)
			{
				Gizmos.DrawLine(pathPoints[i-1].transform.position, pathPoints[i].transform.position);
			}
			
		}
		
}
