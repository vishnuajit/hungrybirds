using UnityEngine;
using System.Collections;

public class BirdDragController : MonoBehaviour {

	public GUIText status;
	// Use this for initialization
	void Start () {
	 status.text="not touched";
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(Input.touchCount == 1 && Input.GetTouch(0).phase== TouchPhase.Began)
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null)// && hit.collider != null) 
			{
			//	Debug.Log ("I'm hitting "+hit.collider.name);
				status.text = "hit on"+hit.transform.gameObject.name;
				}
			
		}
		
	}
}
