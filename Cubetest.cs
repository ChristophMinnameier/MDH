using UnityEngine;
using System.Collections;

public class Cubetest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position.Set(-10,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0.01f,0,0));
	}
}
