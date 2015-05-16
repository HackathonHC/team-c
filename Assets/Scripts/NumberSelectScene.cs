using UnityEngine;
using UniRx;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class NumberSelectScene : MonoBehaviour 
{	
	[SerializeField] private Button P2Btn;
	[SerializeField] private Button P3Btn;
	[SerializeField] private Button P4Btn;

	public static int selectedNumber = 2;  // Default 2 people

	public virtual void Awake() {

		// Get this object.
		// GameObject obj = GameObject.Find("Canvas-NumberSelectScene");
		DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () 
	{
		P2Btn.onClick.AsObservable().Subscribe(_ =>selectedButton(P2Btn));
		P3Btn.onClick.AsObservable().Subscribe(_ =>selectedButton(P3Btn));
		P4Btn.onClick.AsObservable().Subscribe(_ =>selectedButton(P4Btn));
	}
	
	// Update is called once per frame
	void Update () { 
	
	}

	void selectedButton( Button btn ) {

		if ( btn.Equals(this.P2Btn) ) {

			NumberSelectScene.selectedNumber = 2;
		}
		else if ( btn.Equals(this.P3Btn) ) {

			NumberSelectScene.selectedNumber = 3;
		}
		else if ( btn.Equals(this.P4Btn) ) {

			NumberSelectScene.selectedNumber = 4;
		}
		Application.LoadLevel("PlacementScene");
	}
}
