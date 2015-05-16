using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class GameScene : MonoBehaviour 
{
	[SerializeField]
	private Button rectBtn1_1;
	[SerializeField]
	private Button rectBtn1_2;
	[SerializeField]
	private Button rectBtn1_3;
	[SerializeField]
	private Button rectBtn1_4;
	[SerializeField]
	private Button rectBtn1_5;
	[SerializeField]
	private Button rectBtn1_6;
	[SerializeField]
	private Button rectBtn1_7;
	[SerializeField]
	private Button rectBtn2_1;
	[SerializeField]
	private Button rectBtn2_2;
	[SerializeField]
	private Button rectBtn2_3;
	[SerializeField]
	private Button rectBtn2_4;
	[SerializeField]
	private Button rectBtn2_5;
	[SerializeField]
	private Button rectBtn2_6;
	[SerializeField]
	private Button rectBtn2_7;
	[SerializeField]
	private Button rectBtn3_1;
	[SerializeField]
	private Button rectBtn3_2;
	[SerializeField]
	private Button rectBtn3_3;
	[SerializeField]
	private Button rectBtn3_4;
	[SerializeField]
	private Button rectBtn3_5;
	[SerializeField]
	private Button rectBtn3_6;
	[SerializeField]
	private Button rectBtn3_7;
	[SerializeField]
	private Button rectBtn4_1;
	[SerializeField]
	private Button rectBtn4_2;
	[SerializeField]
	private Button rectBtn4_3;
	[SerializeField]
	private Button rectBtn4_4;
	[SerializeField]
	private Button rectBtn4_5;
	[SerializeField]
	private Button rectBtn4_6;
	[SerializeField]
	private Button rectBtn4_7;
	[SerializeField]
	private Button rectBtn5_1;
	[SerializeField]
	private Button rectBtn5_2;
	[SerializeField]
	private Button rectBtn5_3;
	[SerializeField]
	private Button rectBtn5_4;
	[SerializeField]
	private Button rectBtn5_5;
	[SerializeField]
	private Button rectBtn5_6;
	[SerializeField]
	private Button rectBtn5_7;

	[SerializeField]
	private GameObject[] PlayerInfo;

	[SerializeField]
	public GameObject Blind;

	private int playingNumber = 1;
	
	// Use this for initialization
	void Start () {

		rectBtn1_1.onClick.AsObservable().Subscribe(_ =>SlectField(1, 1));
		rectBtn1_2.onClick.AsObservable().Subscribe(_ =>SlectField(1, 2));
		rectBtn1_3.onClick.AsObservable().Subscribe(_ =>SlectField(1, 3));
		rectBtn1_4.onClick.AsObservable().Subscribe(_ =>SlectField(1, 4));
		rectBtn1_5.onClick.AsObservable().Subscribe(_ =>SlectField(1, 5));
		rectBtn1_6.onClick.AsObservable().Subscribe(_ =>SlectField(1, 6));
		rectBtn1_7.onClick.AsObservable().Subscribe(_ =>SlectField(1, 7));
		
		rectBtn2_1.onClick.AsObservable().Subscribe(_ =>SlectField(2, 1));
		rectBtn2_2.onClick.AsObservable().Subscribe(_ =>SlectField(2, 2));
		rectBtn2_3.onClick.AsObservable().Subscribe(_ =>SlectField(2, 3));
		rectBtn2_4.onClick.AsObservable().Subscribe(_ =>SlectField(2, 4));
		rectBtn2_5.onClick.AsObservable().Subscribe(_ =>SlectField(2, 5));
		rectBtn2_6.onClick.AsObservable().Subscribe(_ =>SlectField(2, 6));
		rectBtn2_7.onClick.AsObservable().Subscribe(_ =>SlectField(2, 7));
		
		rectBtn3_1.onClick.AsObservable().Subscribe(_ =>SlectField(3, 1));
		rectBtn3_2.onClick.AsObservable().Subscribe(_ =>SlectField(3, 2));
		rectBtn3_3.onClick.AsObservable().Subscribe(_ =>SlectField(3, 3));
		rectBtn3_4.onClick.AsObservable().Subscribe(_ =>SlectField(3, 4));
		rectBtn3_5.onClick.AsObservable().Subscribe(_ =>SlectField(3, 5));
		rectBtn3_6.onClick.AsObservable().Subscribe(_ =>SlectField(3, 6));
		rectBtn3_7.onClick.AsObservable().Subscribe(_ =>SlectField(3, 7));
		
		rectBtn4_1.onClick.AsObservable().Subscribe(_ =>SlectField(4, 1));
		rectBtn4_2.onClick.AsObservable().Subscribe(_ =>SlectField(4, 2));
		rectBtn4_3.onClick.AsObservable().Subscribe(_ =>SlectField(4, 3));
		rectBtn4_4.onClick.AsObservable().Subscribe(_ =>SlectField(4, 4));
		rectBtn4_5.onClick.AsObservable().Subscribe(_ =>SlectField(4, 5));
		rectBtn4_6.onClick.AsObservable().Subscribe(_ =>SlectField(4, 6));
		rectBtn4_7.onClick.AsObservable().Subscribe(_ =>SlectField(4, 7));
		
		rectBtn5_1.onClick.AsObservable().Subscribe(_ =>SlectField(5, 1));
		rectBtn5_2.onClick.AsObservable().Subscribe(_ =>SlectField(5, 2));
		rectBtn5_3.onClick.AsObservable().Subscribe(_ =>SlectField(5, 3));
		rectBtn5_4.onClick.AsObservable().Subscribe(_ =>SlectField(5, 4));
		rectBtn5_5.onClick.AsObservable().Subscribe(_ =>SlectField(5, 5));
		rectBtn5_6.onClick.AsObservable().Subscribe(_ =>SlectField(5, 6));
		rectBtn5_7.onClick.AsObservable().Subscribe(_ =>SlectField(5, 7));

		this.InitPlayerInfo();
		this.DisplayBlind(this.playingNumber);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void SlectField (int x, int y) {
		Debug.Log("SlectField :" + x.ToString() + y.ToString());

		this.ChangePlayer();
	}

	void InitPlayerInfo()
	{
		int i=0;
		foreach ( GameObject info in PlayerInfo ) {

			if ( i  >= NumberSelectScene.selectedNumber ) {

				info.SetActive(false);
			}

			i++;
		}
	}

	void ChangePlayer()
	{
		int max = NumberSelectScene.selectedNumber;		// 2 ~ 4

		this.playingNumber++;

		if ( this.playingNumber > max ) {

			this.playingNumber = 1;
		}

		this.DisplayBlind(this.playingNumber);
	}

	void DisplayBlind( int number )
	{
		GameObject blind = (GameObject)Instantiate(this.Blind, this.transform.position, this.transform.rotation);
		blind.transform.parent = this.transform;

		Text text = blind.GetComponentInChildren<Text>();
		text.text = "Player " + number;
	}
}
