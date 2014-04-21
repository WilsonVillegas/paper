using UnityEngine;
using System.Collections;

public class ParticleDieQuick : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy(this.gameObject, 2.5f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
