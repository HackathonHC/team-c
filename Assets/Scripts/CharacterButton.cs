using UnityEngine;
using System.Collections;

public class CharacterButton : MonoBehaviour 
{
	[System.NonSerialized] public bool attackRangeEnable;
	[System.NonSerialized] public bool attackMoveEnable;

	public void Reset()
	{
		this.attackMoveEnable  = false;
		this.attackRangeEnable = false;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
