using UnityEngine;
using System.Collections;

public class PlayerParameterPrefs 
{
	private int Id;

	PlayerParameterPrefs (int id)
	{
		Id = id;
	}

	public void SetX (int x)
	{
		PlayerPrefs.SetInt (Id.ToString + "_X", x);
	}

	public void GetX ()
	{
		PlayerPrefs.GetInt (Id.ToString + "_X");
	}

	public void GetY (int x)
	{
		PlayerPrefs.SetInt (Id.ToString + "_Y", x);
	}
	
	public void SetY ()
	{
		PlayerPrefs.GetInt (Id.ToString + "_Y");
	}
	
	public void SetCharacterTypeId (int typeid) 
	{	
		PlayerPrefs.SetInt (Id.ToString + "_CharacterType", typeid);
	}

	public void GetCharacterTypeId () 
	{	
		PlayerPrefs.GetInt (Id.ToString + "_CharacterType");
	}
	
	public void SetDeadFlg ()
	{
		PlayerPrefs.SetInt (Id.ToString + "_DeadFlg", 1);
	}

	public void GetDeadFlg ()
	{
		PlayerPrefs.GetInt (Id.ToString + "_DeadFlg");
	}
}
