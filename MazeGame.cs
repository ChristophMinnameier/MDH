using UnityEngine;
using System.Collections;

public class MazeGame : MonoBehaviour {
	int x;
	public Chessboard m_Board;
	
	public Character m_Player;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
			m_Board.ToggleMousePos();
		if (Input.GetKeyDown(KeyCode.UpArrow))
			m_Player.Move(EDirection.up);
		if (Input.GetKeyDown(KeyCode.DownArrow))
			m_Player.Move(EDirection.down);
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			m_Player.Move(EDirection.left);
		if (Input.GetKeyDown(KeyCode.RightArrow))
			m_Player.Move(EDirection.right);
	}
}
