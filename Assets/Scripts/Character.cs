using UnityEngine;
using System.Collections;

public class Character
{
	enum Type 
	{ 
		Hp = 1,
		Power,
		AttackCount,
		Speed,
		AttackRange,
	};

	public int Id { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
	public int CharacterTypeId { get; set; }
	public int DeadFlg { get; set; }
	public int AttackCount { get; set; }
	public int AttackRange { get; set; }
	public int MoveRange { get; set; }
	public PlayerParameterPrefs Param { get; set; }
	
	public Character (int id) 
	{
		Id = id;
		Param = new PlayerParameterPrefs(Id);
		X = 0;
		Y = 1;
		CharacterTypeId = 1;
		DeadFlg = 0;
		AttackCount = 1;
		AttackRange = 1;
		MoveRange   = 3;
	}

	public void Damage ( int value ) 
	{
		this.DeadFlg = 1;
	}

	void Save () 
	{
		Param.SetX(X);
		Param.SetY(Y);
		Param.SetCharacterTypeId(CharacterTypeId);
		Param.SetDeadFlg(DeadFlg);
		Param.SetAttackCount(AttackCount);
		Param.SetAttackRange(AttackRange);
	}
}
