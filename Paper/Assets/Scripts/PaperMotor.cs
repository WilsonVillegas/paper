using UnityEngine;
using System.Collections;

public class PaperMotor : MonoBehaviour {

	public float speed;
	public bool hit = false;
	public bool started = false;
	public bool fan = false;
	public int lives;
	public string m_levelName;
	float OriginalSpeed;
	float DoubleSpeed;
	float HalfSpeed;
	Vector3 position;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(StartLevel());
		OriginalSpeed = speed;
		HalfSpeed = speed/4;
	}
	
	// Update is called once per frame
	void Update () {
		position = transform.position;
		//Quaternion wantedRotation = new Vector3(0,0,0);
		if(!hit && started && !fan)
		{
			if(Input.GetButton("Jump"))
			{
				speed = HalfSpeed;
			}
			else
				speed = OriginalSpeed;

			#region Horizontal Rotation
			if(Input.GetAxis("Horizontal") > 0)
				transform.Rotate(0,30 * Time.deltaTime,0);
			else if(Input.GetAxis("Horizontal") < 0)
				transform.Rotate(0,-30 * Time.deltaTime,0);
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

			transform.Translate(0,0, speed * Time.deltaTime);
		}
		if(hit)
		{
			transform.Translate(0,speed * Time.deltaTime / 5, 0);
			transform.Rotate(-10 * Time.deltaTime, 0,0);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Hit something PLANE" + lives);

		lives--;

<<<<<<< HEAD
		Application.LoadLevel(1);
=======
		Application.LoadLevel(m_levelName);
>>>>>>> deda20dde1aa14c7d0cb6b769a2b6245d4af8ea3
		//hit = true;
	}

	void OnTriggerEnter(Collider other)
	{	
		if(other.gameObject.tag == "NegXWind")
		{
			Debug.Log("Hit NegXWind zone");
		}

		Debug.Log("Hit something!");

	}

	private IEnumerator StartLevel()
	{
		yield return new WaitForSeconds(2);
		started = true;
	}




}
