using UnityEngine;
using System.Collections;

public class BirdDragController : MonoBehaviour {

	public GUIText status;
	public GameObject dot;
	private Vector3 startPos;
	private float totalXMoved;
	private float totalYMoved;
	private float totalMovedDistance;
	
	// Use this for initialization
	void Start () {
	 status.text="not touched";
	 startPos = transform.position;
	}
	void resetPos()
	{
		transform.position = startPos;
		totalXMoved=0.0f;
		totalYMoved=0.0f;
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
				//status.text= "touch delta"+Input.GetTouch(0).deltaPosition;
				if(hit.transform.gameObject.name=="bird")
				{
					
					
					float xMoved = Input.GetTouch(0).deltaPosition.x * 0.1f;
					float yMoved = Input.GetTouch(0).deltaPosition.y * 0.1f;
					totalXMoved += xMoved;
					totalYMoved += yMoved;
					
					totalMovedDistance = Mathf.Sqrt(totalXMoved*totalXMoved+totalYMoved*totalYMoved);
					
					if(totalMovedDistance < 3.0f)
					{
						status.text = "Total moved distance="+totalMovedDistance;
						//Vector3 bpos = new Vector3(1,0,0);
						Vector3 bpos = new Vector3(xMoved,yMoved,0);
						transform.Translate(bpos);
						
						Vector3 dpos = new Vector3(-totalXMoved,-totalYMoved,0.0f);
						dot.transform.position = dpos;
					}
					else
					{
						resetPos();
						
					}
					
				}
			}
			
			
		}
		else
		{
			if(Input.touchCount==0)
			{
				resetPos();
			}
		}
		
	}
}
