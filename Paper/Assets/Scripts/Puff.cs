using UnityEngine;
using System.Collections;

public class Puff : MonoBehaviour {

	public GameObject particles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {
		Instantiate(particles, this.gameObject.transform.position, this.gameObject.transform.rotation);
	}
}
