using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	
	static string text;
	public GameObject plane;
	void Start () 
	{
		Vector2 guiPosiition = new Vector2(Screen.width/3, Screen.height/3);
		guiText.pixelOffset = guiPosiition;
	}

	void Update () 
	{	
		text = plane.GetComponent<PaperMotor>().collectibles.ToString();
		guiText.text = text + "/9";
	}
}
