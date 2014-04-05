using UnityEngine;
using System.Collections;

public class PaperPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		//Quaternion wantedRotation = new Vector3(0,0,0);

		#region Horizontal Rotation
		if(Input.GetAxis("Horizontal") > 0)
			transform.Rotate(0,30 * Time.deltaTime,30 * Time.deltaTime);
		else if(Input.GetAxis("Horizontal") < 0)
			transform.Rotate(0,-30 * Time.deltaTime,-30 * Time.deltaTime);
		else
			transform.Rotate(0,0,0);
		#endregion		

		#region Vertical Rotation
		if(Input.GetAxis("Vertical") < 0)
			transform.Rotate(30 * Time.deltaTime, 0,0);
		else if(Input.GetAxis("Vertical") > 0)
			transform.Rotate(-30 * Time.deltaTime, 0,0);
		//else
			//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, 180,0), (Time.smoothDeltaTime + Time.deltaTime)/2 * 5.0f);
		#endregion
	}

	void onTriggerEnter(Collider other)
	{
		Application.LoadLevel(0);
	}


}
