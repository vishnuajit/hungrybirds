using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public GUIText statusText;
	public GameObject bird;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int nTouches = Input.touchCount;
		
		if(nTouches > 0)
		{
			statusText.text="Status:"+nTouches+"touches Detected";
			
			for(int i = 0; i < nTouches; i++)
			{
				Touch touch = Input.GetTouch(i);
				statusText.text+= "\n"+"Touch index"+touch.fingerId+"detected at position"+touch.position;
				
				if(touch.phase == TouchPhase.Began)
				{
					Ray screenRay = Camera.main.ScreenPointToRay(touch.position);
					RaycastHit hit;
					
					if(Physics.Raycast(screenRay, out hit))
					{ 
						
						if(hit.collider.gameObject.name=="bird")
						{
							Vector3 birdpos = new Vector3(touch.position.x,touch.position.y,0);
							bird.transform.position = birdpos;
							statusText.text="hit on bird";
						}
					}
				}
			}
		}
	}
}
