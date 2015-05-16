using UnityEngine;
using UniRx;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class NumberSelectScene : MonoBehaviour {
	
	[SerializeField] private Button p2Btn;
	[SerializeField] private Button p3Btn;
	[SerializeField] private Button p4Btn;
	
	// Use this for initialization
	void Start () {

		p2Btn.onClick.AsObservable().Subscribe(_ =>selectedButton(p2Btn));
		p3Btn.onClick.AsObservable().Subscribe(_ =>selectedButton(p3Btn));
		p4Btn.onClick.AsObservable().Subscribe(_ =>selectedButton(p4Btn));
	}
	
	// Update is called once per frame
	void Update () { 
	
	}

	void selectedButton( Button btn ) {

		if ( btn.Equals(this.p2Btn) ) {
			Debug.Log("SELECTED : 2" );
		}
		else if ( btn.Equals(this.p3Btn) ) {
			Debug.Log("SELECTED : 3" );
		}
		else if ( btn.Equals(this.p4Btn) ) {
			Debug.Log("SELECTED : 4" );
		}
	}
}
