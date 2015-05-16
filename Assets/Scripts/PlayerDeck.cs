using UnityEngine;
using System.Collections;

public class PlayerDeck
{
	private int Id { get; set; }
	public ArrayList characters = new ArrayList();

	public PlayerDeck(int id) 
	{
		Id = id;
	}

	public void Clear()
	{
		characters.Clear();
	}
}
