using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	
	static string text;
	public GameObject plane;
	void Start () 
	{
		Vector2 guiPosiition = new Vector2(0, Screen.height/3);
		guiText.pixelOffset = guiPosiition;
	}

	void Update () 
	{	
		text = plane.GetComponent<PaperMotor>().lives.ToString();
		guiText.text = "x" + text;
	}
}
