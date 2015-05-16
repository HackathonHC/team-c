using UnityEngine;
using UniRx;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ResultScene : MonoBehaviour 
{
	[SerializeField] private Button ContinueBtn;

	
	// Use this for initialization
	void Start () {

		ContinueBtn.onClick.AsObservable().Subscribe(_ =>Continue());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Continue()
	{
		// Back to title or NumberSelectScene.
		Application.LoadLevel("NumberSelectScene");
	}
}
