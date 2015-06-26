using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class square : MonoBehaviour
{

	private bool m_bAlive;
	
	int m_iCol;
	int m_iRow;
	
	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{

	}
	
	public void SetPos(int _iCol, int _iRow)
	{
		transform.position = new Vector3(_iCol, _iRow, 0);
		name = "Quad("+_iCol+","+_iRow+")";
		if (Random.value < 0.5)
			SetAlive(true);
		m_iCol = _iCol;
		m_iRow = _iRow;
	}
	
	public List<square> GetNeighbours(Chessboard _Board)
	{
		List<square> neighs = new List<square>();
		for (int iColDelta = -1; iColDelta <= 1; iColDelta++)
			for (int iRowDelta = -1; iRowDelta <= 1; iRowDelta++)
		{
			if (iColDelta == 0 && iRowDelta == 0) // don’t check yourself
				continue;
			int iNeighCol = m_iCol + iColDelta;
			int iNeighRow = m_iRow + iRowDelta;
			if  (iNeighCol >= 0 && iNeighCol < _Board.m_iSize &&
			     iNeighRow >= 0 && iNeighRow < _Board.m_iSize)
					neighs.Add(_Board.GetSquare(iNeighCol, iNeighRow));
		}
		return neighs;	
	}
	
	public bool GetAlive() 
	{
		return m_bAlive;
	}
	
	public void SetAlive(bool _bAlive)
	{
		m_bAlive = _bAlive;
		renderer.material.color = _bAlive ? Color.blue : Color.white;
	}
}

