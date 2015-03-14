using UnityEngine;
using System.Collections;

public class BirdDragController : MonoBehaviour {

	public GUIText status;
	public GameObject dot;
	private Vector3 startPos;
	private float totalXMoved;
	private float totalYMoved;
	private float totalMovedDistance;
	private bool dragFinished=false;
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
	
		GameUpdate();
	
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
					
					dragFinished = true;
					/*
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
						
						//Vector3 dpos = new Vector3(-totalXMoved,-totalYMoved,0.0f);
						//dot.transform.position = dpos;
						
					}
					else
					{
						resetPos();
						
					}
					*/
					
				}
			}
			
			
		}
		else
		{
			for(int i =0; i < Input.touchCount;i++)
			{
				Touch touch = Input.GetTouch(i);
				
				
					if(touch.phase == TouchPhase.Ended)
					{
					//	dragFinished=true;
						status.text = "drag finished,touch lifteed";			
					}
				
			}
			
		}
		
	}
	void GameUpdate()
	{
		if(dragFinished)
		{
			status.text="touched bird";
			Vector2 moveVector = new Vector2(150,100);
			//moveVector.Normalize();
		//	moveVector = new Vector2(moveVector.x *5 , moveVector.y*5 );
			rigidbody2D.AddForce(moveVector);
			dragFinished = false;
		}
	}
}
