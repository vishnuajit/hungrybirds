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
	
		if(Input.touchCount == 1 && Input.GetTouch(0).phase== TouchPhase.Moved)
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.GetTouch(0).position);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit != null)// && hit.collider != null) 
			{
			//	Debug.Log ("I'm hitting "+hit.collider.name);
				//status.text = "hit on"+hit.transform.gameObject.name;
				status.text= "touch delta"+Input.GetTouch(0).deltaPosition;
				if(hit.transform.gameObject.name=="bird")
				{
					status.text = "Touched at"+Input.GetTouch(0).position;
					//Vector3 bpos = new Vector3(1,0,0);
					Vector3 bpos = new Vector3(Input.GetTouch(0).deltaPosition.x*0.1f,Input.GetTouch(0).deltaPosition.y*0.1f,0);
					transform.Translate(bpos);
					
				}
				}
			
		}
		
	}
}
