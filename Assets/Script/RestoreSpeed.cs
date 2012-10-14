using UnityEngine;
using System.Collections;

public class RestoreSpeed : MonoBehaviour 
{
	public float originalSpeed;
	public float time;
	public GameObject restoreSpeedObject;
		
	// Use this for initialization
	void Start () 
	{
		Invoke("RestoreSpeedFunction",time);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void RestoreSpeedFunction()
	{
		PathThroughObjcets scriptInstance = gameObject.transform.parent.GetComponent<PathThroughObjcets>();
		scriptInstance.speed = originalSpeed;
		Destroy(gameObject);
	}
}
