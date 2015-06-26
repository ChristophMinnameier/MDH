using UnityEngine;
using System.Collections;

public class GameOfLife : MonoBehaviour
{
	public Chessboard m_Board;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.K))
			m_Board.KillAll();
		
		if (Input.GetMouseButtonDown(0))
			m_Board.ToggleMousePos();

		
		if (Input.GetKeyDown(KeyCode.Space) == false)
			return;
		
		// create array to store num alive neighbours before changing anythin
		int[,] NumAliveNeighs = new int[m_Board.m_iSize,m_Board.m_iSize];
		for (int iCol = 0; iCol < m_Board.m_iSize; iCol++)
			for (int iRow = 0; iRow < m_Board.m_iSize; iRow++)
				NumAliveNeighs[iCol, iRow] = m_Board.GetAliveNeighbours(iCol, iRow);
		// store num alive
		for (int iCol = 0; iCol < m_Board.m_iSize; iCol++)
			for (int iRow = 0; iRow < m_Board.m_iSize; iRow++)
		{
			int iNumAlive = NumAliveNeighs[iCol, iRow];
			// alive
			if (m_Board.GetSquare(iCol, iRow).GetAlive()) {
				if (iNumAlive < 2 || iNumAlive > 3)
					m_Board.GetSquare(iCol, iRow).SetAlive(false);
			}
			// dead
			else
				if (iNumAlive == 3)
					m_Board.GetSquare(iCol, iRow).SetAlive(true);
		}
	}
}

