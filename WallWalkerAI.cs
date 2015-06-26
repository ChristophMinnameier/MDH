using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallWalkerAI : MonoBehaviour {

	public Character m_Char;
	
	public EDirection m_Direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	
	float m_fTimer;
	
	void Update () {
		m_fTimer -= Time.deltaTime;
		if (m_fTimer > 0f)
			return;
			
		m_fTimer = 0.5f;
		Move();
	}
	
void Move() {
	int iCheckCol = m_Char.m_iCol;
	int iCheckRow = m_Char.m_iRow;
	
	switch (m_Direction) {
		case EDirection.left:
			iCheckCol -= 1;
			break;
		case EDirection.right:
			iCheckCol += 1;
			break;
		case EDirection.up:
			iCheckRow += 1;
			break;
		case EDirection.down:
			iCheckRow -= 1;
			break;
	}
		
	square checkSquare = m_Char.m_Board.GetSquare(iCheckCol, iCheckRow);
	
	// walkable
	if (checkSquare != null && checkSquare.GetAlive() == false)
		m_Char.Move(m_Direction);
	// not walkable
	else
		m_Direction = Foo.GetLeft(m_Direction);
}
}
