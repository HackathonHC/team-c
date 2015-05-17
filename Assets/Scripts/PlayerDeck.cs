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

	public int GetAliveCount()
	{
		int count =0;

		foreach ( Character chara in characters ) {

			if ( chara.DeadFlg == 0 ) {

				count++;
			}
		}

		return count;
	}
}
