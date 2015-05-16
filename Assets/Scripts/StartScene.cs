using UnityEngine;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class StartScene : MonoBehaviour {

	[SerializeField]
	private Button startBtn;

	// Use this for initialization
	void Start () {
		startBtn.onClick.AsObservable().Subscribe(_ =>GameStart());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GameStart () {
		Application.LoadLevel("NumberSelectScene");
	}
}
