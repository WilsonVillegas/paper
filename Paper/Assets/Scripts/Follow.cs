using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public Transform target;
	public float distance = .18f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;

	//Note: This should be FixedUpdate, but the camera stutters wildly in that case, so this is the preferred method
	void Update () {
		Vector3 wantedPosition;
		if(followBehind)
			wantedPosition = target.TransformPoint(0, height, -distance);
		else
			wantedPosition = target.TransformPoint(0, height, distance);
		
		transform.position = Vector3.Lerp (transform.position, wantedPosition, (Time.smoothDeltaTime + Time.deltaTime)/2 * damping);
		
		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, (Time.smoothDeltaTime + Time.deltaTime)/2 * rotationDamping);
		}
		else transform.LookAt (target, target.up);
	}
}