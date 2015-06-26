using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int m_iRow = 0;
	public int m_iCol = 0;
	
	public Chessboard m_Board;
	

	// Use this for initialization
	void Start () {
		SetPos(m_iCol, m_iRow);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Move(EDirection _Dir)
	{
		switch (_Dir)
		{
			case EDirection.left:
				SetPos(m_iCol-1, m_iRow);
				break;
			case EDirection.right:
				SetPos(m_iCol+1, m_iRow);
				break;
			case EDirection.up:
				SetPos(m_iCol, m_iRow+1);
				break;
			case EDirection.down:
				SetPos(m_iCol, m_iRow-1);
				break;
		}
	}
	
	void SetPos(int _iCol, int _iRow)
	{
		if (m_Board.IsWalkable(_iCol, _iRow) == false)
			return;
		m_iCol = _iCol;
		m_iRow = _iRow;
		transform.position = m_Board.GetFieldCenter(m_iCol, m_iRow);
	}
}
