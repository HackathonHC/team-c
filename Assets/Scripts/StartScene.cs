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
//		GameObject aaa = GameObject.Find("EffectHit1");
//		aaa.transform.position = new Vector2(3,3);
//		ParticleSystem particleSystem = aaa.GetComponent<ParticleSystem>();
//		particleSystem.Play();
		AudioManager.Instance.PlayBGM("default_bgm");
		startBtn.onClick.AsObservable().Subscribe(_ =>GameStart());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GameStart () {
		AudioManager.Instance.PlaySE("submit");
		Application.LoadLevel("NumberSelectScene");
	}
}
