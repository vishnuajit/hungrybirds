using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public GUIText statusText;
	
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
			}
		}
	}
}
