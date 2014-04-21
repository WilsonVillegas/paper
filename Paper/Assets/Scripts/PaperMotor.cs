using UnityEngine;
using System.Collections;

public class PaperMotor : MonoBehaviour {

	public float speed;
	public bool hit = false;
	public bool paused = false;
	public bool started = false;
	private bool fan;
	public int collectibles;
	public string m_levelName;
	float OriginalSpeed;
	float DoubleSpeed;
	float HalfSpeed;
	public Vector3 startPosition;
	public Vector3 startRotation;
	public GameObject[] Pieces;
	//TODO Add boolean to tell camera whether or not to follow the plane!
	// Use this for initialization
	void Start () 
	{
		startRotation.x = transform.rotation.x;
		startRotation.y = 276;
		startRotation.z = transform.rotation.z;
		StartCoroutine(StartLevel());
		OriginalSpeed = speed;
		HalfSpeed = speed/4;
		fan = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Quaternion wantedRotation = new Vector3(0,0,0);

		if (Input.GetKeyDown("p"))
		{
			if(!paused)
			{
				Time.timeScale = 0;
				paused = true;
			}
			else
			{
				Time.timeScale =1;				
				paused = false;
			}
		}

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
			else
				transform.Rotate(-3 * Time.deltaTime, 0,0);
			//else
				//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler(0, 180,0), (Time.smoothDeltaTime + Time.deltaTime)/2 * 5.0f);
			#endregion

			transform.Translate(0,0, speed * Time.deltaTime);
		}
		if(fan)
		{
			transform.Translate(speed * Time.deltaTime/2, 0, 0);
			transform.Rotate(-15 * Time.deltaTime, 0,0);
		}
	}

	void OnCollisionEnter(Collision other)
	{

		hit = true;
		started = false;
		StartCoroutine(ResetTime());
		StartCoroutine(StartLevel());
		Reset();	


		//Application.LoadLevel(m_levelName);
	}

	public void Reset()
	{
		transform.localEulerAngles = startRotation;
		transform.position = startPosition;
		hit = false;
		fan = false;
	}

	void OnTriggerEnter(Collider other)
	{	
		if(other.gameObject.tag == "NegXWind")
		{
			Debug.Log("Hit NegXWind zone");
			fan = true;
		}
		if(other.gameObject.tag == "Piece 1")
		{
			Debug.Log("Hit First Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[0].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 2")
		{
			Debug.Log("Hit Second Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[1].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 3")
		{
			Debug.Log("Hit Third Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[2].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 4")
		{
			Debug.Log("Hit Fourth Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[3].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 5")
		{
			Debug.Log("Hit Fifth Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[4].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 6")
		{
			Debug.Log("Hit Sixth Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[5].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 7")
		{
			Debug.Log("Hit Seventh Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[6].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 8")
		{
			Debug.Log("Hit Eighth Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[7].gameObject.SetActive(true);
		}
		if(other.gameObject.tag == "Piece 9")
		{
			Debug.Log("Hit Ninth Piece");
			Destroy(other.gameObject);
			collectibles++;
			Pieces[8].gameObject.SetActive(true);
		}

		Debug.Log("Hit something!");

	}

	private IEnumerator StartLevel()
	{
		yield return new WaitForSeconds(2);
		started = true;
	}	

	private IEnumerator ResetTime()
	{
		yield return new WaitForSeconds(3);
	}




}
