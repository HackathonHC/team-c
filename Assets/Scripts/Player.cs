using UnityEngine;
using System.Collections;

public class Player
{
	public int Id { get; set; }
	public PlayerDeck deck { get; set; }
	public int ranking { get; set; }

	public Player (int _id, PlayerDeck _deck)
	{
		Id = _id;
		deck = _deck;
		ranking = 0;
	}

	public bool IsDropOut()
	{
		if ( deck.GetAliveCount() <= 0 ) {

			return true;
		}

		return false;
	}

}
