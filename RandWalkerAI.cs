using UnityEngine;
using System.Collections;

public class RandWalkerAI : MonoBehaviour {

	public Character m_Char;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
	float m_fTimer;
	
	void Update () {
		m_fTimer -= Time.deltaTime;
		if (m_fTimer > 0f)
			return;
		
		m_fTimer = 1f;
		RandomMove();
	}
	
	void RandomMove() {
		System.Array values = EDirection.GetValues(typeof(EDirection));
		int randomIndex = Random.Range(0,values.Length);
		EDirection Dir = (EDirection)values.GetValue(randomIndex);
		m_Char.Move(Dir);
	}
}
