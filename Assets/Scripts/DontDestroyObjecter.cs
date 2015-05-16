using UnityEngine;
using System.Collections;

public class DontDestroyObjecter
{

	public int selected_number;
	public ArrayList player_list;

	public DontDestroyObjecter(int _selected_number, ArrayList _player_list)
	{
		selected_number = _selected_number;
		player_list = _player_list;
	}
}
