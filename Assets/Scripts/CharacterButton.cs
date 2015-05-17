using UnityEngine;
using System.Collections;

public class CharacterButton : MonoBehaviour 
{
	[System.NonSerialized] public bool attackRangeEnable;
	[System.NonSerialized] public bool moveRangeEnable;

	public void Reset()
	{
		this.moveRangeEnable   = false;
		this.attackRangeEnable = false;
	}

	// Use this for initialization
	void Start () {

		this.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
