using UnityEngine;
using System.Collections;

public class Player
{
	private int Id { get; set; }
	private int X { get; set; }
	private int Y { get; set; }
	private int CharacterTypeId { get; set; }
	private int DeadFlg { get; set; }
	private PlayerParameterPrefs Param { get; set; }

	Player (int id) 
	{
		Id = id;
		Param = new PlayerParameterPrefs(Id);
		X = 0;
		Y = 1;
		CharacterTypeId = 1;
		DeadFlg = 0;
	}

	void Save () 
	{
		Param.SetX(X);
		Param.SetY(Y);
		Param.SetCharacterTypeId(CharacterTypeId);
		Param.SetDeadFlg(DeadFlg);
	}

}
