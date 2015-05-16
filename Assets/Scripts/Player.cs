using UnityEngine;
using System.Collections;

public class Player
{
	public int Id { get; set; }
	public PlayerDeck deck { get; set; }

	public Player (int _id, PlayerDeck _deck)
	{
		Id = _id;
		deck = _deck;
	}
}
