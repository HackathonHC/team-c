using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;

public class Blind : MonoBehaviour 
{
	private Image  Background;
	private Button PlayButton;

	void Awake()
	{
		Background = this.GetComponentInChildren<Image> ();
		PlayButton = this.GetComponentInChildren<Button> ();

		if ( PlayButton ) {

			PlayButton.onClick.AsObservable().Subscribe(_ =>Destroy(this.gameObject));
		}
	}

	// Use this for initialization
	void Start () {

		/*
		iTween.FadeTo (Background.gameObject, iTween.Hash(
			"alpha", 1.0f,
			"time", 2.0f
			));
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
