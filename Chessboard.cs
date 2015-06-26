using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chessboard : MonoBehaviour {

	public int m_iSize = 10;

	protected square[,] m_Grid;

	// Use this for initialization
	void Awake () {
		m_Grid = new square[m_iSize,m_iSize];
	 
		for (int i = 0; i < m_iSize; i++)
			for (int j = 0; j < m_iSize; j++)
		{
			GameObject kachel = GameObject.CreatePrimitive(PrimitiveType.Quad);
			kachel.transform.parent = this.transform;
			m_Grid[i,j] = kachel.AddComponent("square") as square;
			m_Grid[i,j].SetPos(i,j);
		}
		
		Camera.main.transform.position = new Vector3(m_iSize/2, m_iSize/2, -100);
		Camera.main.orthographicSize = m_iSize/2;
		
		transform.position = new Vector3(0.5f,0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	public int GetAliveNeighbours(int _iCol, int _iRow)
	{
		List<square> Neighs = GetSquare(_iCol, _iRow).GetNeighbours(this);
		int iNumAliveNeighbours = 0;
		foreach (square neigh in Neighs)
			if (neigh.GetAlive())
				iNumAliveNeighbours++;
				
		return iNumAliveNeighbours;
	}
	
	public square GetSquare(int _iCol, int _iRow)
	{
		if (_iCol < 0 || _iRow < 0 || _iCol >= m_iSize || _iRow >= m_iSize)
			return null;
		return m_Grid[_iCol, _iRow];
	}
	
	public void KillAll()
	{
		for (int iCol = 0; iCol < m_iSize; iCol++)
			for (int iRow = 0; iRow < m_iSize; iRow++)
				m_Grid[iCol, iRow].GetComponent<square>().SetAlive(false);
	}
	
	public void Toggle(int _iCol, int _iRow)
	{
		if (m_Grid[_iCol, _iRow].GetComponent<square>().GetAlive() == false)
			m_Grid[_iCol, _iRow].GetComponent<square>().SetAlive(true);
		else
			m_Grid[_iCol, _iRow].GetComponent<square>().SetAlive(false);
	}
	
	public void ToggleMousePos()
	{
		Vector3 MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		int iIndexX = (int)(MouseWorldPos.x); 
		int iIndexY = (int)(MouseWorldPos.y); 
		Toggle(iIndexX, iIndexY);
	}
	
	public Vector3 GetFieldCenter(int _iCol, int _iRow)
	{
		return m_Grid[_iCol, _iRow].transform.position;
	}
	
	public bool IsWalkable(int _iCol, int _iRow)
	{
		square Square = GetSquare(_iCol, _iRow);
		return (Square != null && Square.GetAlive() == false); 
	}
}
