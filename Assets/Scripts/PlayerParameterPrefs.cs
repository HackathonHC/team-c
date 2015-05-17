using UnityEngine;
using System.Collections;

public class PlayerParameterPrefs 
{
	private int Id;

	public PlayerParameterPrefs (int id)
	{
		Id = id;
	}

	public void SetX (int x)
	{
		PlayerPrefs.SetInt (Id.ToString() + "_X", x);
	}

	public void GetX ()
	{
		PlayerPrefs.GetInt (Id.ToString() + "_X");
	}

	public void SetY (int y)
	{
		PlayerPrefs.SetInt (Id.ToString() + "_Y", y);
	}
	
	public void GetY ()
	{
		PlayerPrefs.GetInt (Id.ToString() + "_Y");
	}
	
	public void SetCharacterTypeId (int typeid) 
	{	
		PlayerPrefs.SetInt (Id.ToString() + "_CharacterType", typeid);
	}

	public void GetCharacterTypeId () 
	{	
		PlayerPrefs.GetInt (Id.ToString() + "_CharacterType");
	}
	
	public void SetDeadFlg (int deadFlg)
	{
		PlayerPrefs.SetInt (Id.ToString() + "_DeadFlg", deadFlg);
	}

	public void GetDeadFlg ()
	{
		PlayerPrefs.GetInt (Id.ToString() + "_DeadFlg");
	}

	public void SetAttackCount ( int count )
	{
		PlayerPrefs.SetInt (Id.ToString() + "_AttackCount", count);
	}

	public void GetAttackCount ()
	{
		PlayerPrefs.GetInt (Id.ToString() + "_AttackCount");
	}

	public void SetAttackRange ( int range )
	{
		PlayerPrefs.SetInt (Id.ToString() + "_AttackRange", range);
	}
	
	public void GetAttackRange ()
	{
		PlayerPrefs.GetInt (Id.ToString() + "_AttackRange");
	}
}
