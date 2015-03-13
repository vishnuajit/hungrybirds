using UnityEngine;
using System.Collections;

public class BirdDragController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(Input.touchCount == 1 && Input.GetTouch(0).phase== TouchPhase.Began)
		{
			float x = Input.GetTouch(0).position.x;
			Vector3 pos = new Vector3(1,0,0);
			transform.position += pos;
		}
		
	}
}
