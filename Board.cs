using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
/*asd*/
	public int iSize = 10;
	
	GameObject[,] board;
	
	public enum Direction
	{
		Left,
		Right,
		Up,
		Down
	}
	
	public struct IndexPaar
	{
		public int zeile;
		public int spalte;
		
		public IndexPaar GetNeighbour(Direction _Dir)
		{
			IndexPaar Neighbour = this;
			switch (_Dir)
			{
				case Direction.Left:
					Neighbour.spalte -= 1;
					break;
			case Direction.Right:
					Neighbour.spalte += 1;
					break;
			case Direction.Up:
					Neighbour.zeile -= 1;
					break;
			case Direction.Down:
					Neighbour.zeile += 1;
					break;
			}
			
			return Neighbour;
		}
	}
	
	
	
	public bool IsKachelBlocked(IndexPaar _Pair)
	{
		GameObject Kachel = GetKachel(_Pair);
		return (Kachel == null || Kachel.renderer.material.color == Color.blue); 
	}
	
	public bool IsValid(IndexPaar _Pair)
	{
		return (0 <= _Pair.zeile && _Pair.zeile < iSize && 
		        0 <= _Pair.spalte && _Pair.spalte < iSize); 
	}
	
	public GameObject GetKachel(IndexPaar _Pair)
	{
		if (IsValid(_Pair) == false)
			return null;
		return board[_Pair.spalte, _Pair.zeile];
	}
	
	int[,] distance;
	Queue<IndexPaar> warteschlange = new Queue<IndexPaar>();

	// Use this for initialization
	void Start () {
		board = new GameObject[iSize,iSize];
		distance = new int[iSize,iSize];
	
		for (int i = 0; i < iSize; i++)
			for (int j = 0; j < iSize; j++)
			{
				GameObject kachel = GameObject.CreatePrimitive(PrimitiveType.Quad);
				kachel.transform.position = new Vector3(i, j, 0);
				if (Random.value < 0.5)
					kachel.renderer.material.color = Color.blue;
				board[i,j] = kachel;
				
				kachel.transform.parent = this.transform;
				kachel.name = "Quad("+i+","+j+")";
		}
		
		Camera.main.transform.position.Set(iSize/2, iSize/2, -10);
		transform.position.Set(0.5f, 0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			print ("Clicked on: " + MouseWorldPos);
			int iIndexX = (int)(MouseWorldPos.x); 
			int iIndexY = (int)(MouseWorldPos.y); 
			print ("Index pair : " + iIndexX + "/" + iIndexY);
			
			IndexPaar paar;
			paar.zeile = iIndexY;
			paar.spalte = iIndexX;
			if (IsValid(paar))
		    {
		    /*
		    	GameObject Kachel = board[iIndexX, iIndexY];
		    	if (Kachel.renderer.material.color == Color.blue)
					Kachel.renderer.material.color = Color.white;
				else
					Kachel.renderer.material.color = Color.blue;
			*/
			}
			
			
			StartBreitensuche(paar);
			
			
			for (int i = 0; i < iSize; i++)
				for (int j = 0; j < iSize; j++)
				{
					IndexPaar Paar;
					Paar.spalte = i;
					Paar.zeile = j;
					if (distance[j,i] != int.MaxValue)
					{
						GameObject Kachel = GetKachel(Paar);
						Kachel.renderer.material.color = Color.red;
					}
				}
		}
	}
	
	void ResetBreitensuche()
	{
		for (int i = 0; i < iSize; i++)
			for (int j = 0; j < iSize; j++)
				distance[i,j] = int.MaxValue;
				
		warteschlange.Clear();
	}
	
	void StartBreitensuche(IndexPaar _Start)
	{
		ResetBreitensuche();
		
		if (IsKachelBlocked(_Start))
		return;
		
		warteschlange.Enqueue(_Start);
		distance[_Start.zeile, _Start.spalte] = 0;
		
		while (warteschlange.Count > 0)
		{
			IndexPaar This = warteschlange.Dequeue();
			
			List<IndexPaar> Neighbours = GetNeighbours(This);
			
			foreach (IndexPaar Neigh in Neighbours)
			{
				if (distance[Neigh.zeile, Neigh.spalte] == int.MaxValue)
				{
					distance[Neigh.zeile, Neigh.spalte] = 1 + distance[This.zeile, This.spalte];
					warteschlange.Enqueue(Neigh);
					print ("new dist: " + distance[Neigh.zeile, Neigh.spalte]);
				}
			}
			
			// TODO Übungsaufgabe: erstmal hard-coded neighbours benutzen
			// TODO Übungsaufgabe: dann getneighbours funktion erstellen
			// TODO Übungsaufgabe: dann funktionen left(indexpair _node) right(indexpair _node) etc für indexpaar definieren
			// TODO Übungsaufgabe: dann diese funktionen in die indexpair-klasse verschieben
			// TODO Übungsaufgabe: dann isvalid() funktion in indexpair-klasse 
			// TODO Übungsaufgabe: dann enum directions definieren und getneighbour(dir)
		}
	}
	
	List<IndexPaar> GetNeighbours(IndexPaar _Node)
	{
		List<IndexPaar> Neighbours = new List<IndexPaar>();
		foreach(Direction dir in System.Enum.GetValues(typeof(Direction)))
		{
			IndexPaar Neighbour = _Node.GetNeighbour(dir);
			if (IsValid(Neighbour) && IsKachelBlocked(Neighbour) == false)
				Neighbours.Add(Neighbour);
		}
		return Neighbours;
	}
}
