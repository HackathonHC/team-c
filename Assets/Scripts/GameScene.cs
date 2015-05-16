using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class GameScene : MonoBehaviour 
{
	[SerializeField]
	private GameObject field;
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
	private GameObject[] playerInfo;
	[SerializeField]
	private GameObject blind;
	[SerializeField]
	private Sprite	characterSprite1;
	[SerializeField]
	private Sprite	characterSprite2;
	[SerializeField]
	private Sprite	characterSprite3;
	[SerializeField]
	private Sprite	characterSprite4;
	[SerializeField]
	private Sprite	characterSprite5;
	[SerializeField]
	private Sprite	emptySprite;

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

		this.DisplayBlind(this.playingNumber);
		this.InitPlayerInfo();
		this.ResetCharacter();
		this.SetupPlayers(this.GetPlayerList());
	}

	// Update is called once per frame
	void Update () {
	
	}

	void SlectField (int x, int y) {

		this.ChangePlayer();
	}
	
	void InitPlayerInfo()
	{
		int i=0;
		foreach ( GameObject info in playerInfo ) {

			if ( i  >= this.GetSelectedNumber() ) {

				info.SetActive(false);
			}

			i++;
		}
	}

	void ChangePlayer()
	{
		int max = this.GetSelectedNumber();		// 2 ~ 4

		this.playingNumber++;

		if ( this.playingNumber > max ) {

			this.playingNumber = 1;
		}

		this.DisplayBlind(this.playingNumber);
		this.ResetCharacter();
		this.SetupPlayers (this.GetPlayerList());
	}

	void DisplayBlind( int number )
	{
		GameObject blind = (GameObject)Instantiate(this.blind, this.transform.position, this.transform.rotation);
		blind.transform.parent = this.transform;

		Text text = blind.GetComponentInChildren<Text>();
		text.text = "Player " + number;
	}

	void SetupPlayers( ArrayList playerList )
	{
		int    index  = this.playingNumber - 1;
		Player player = (Player)playerList[index];
		this.SetupPlayer (player);
	}

	void SetupPlayer( Player player )
	{
		PlayerDeck deck       = player.deck;
		ArrayList  characters = deck.characters;

		for ( int i=0; i < characters.Count; i++ ) {

			Character chara = (Character)characters[i];
			this.PlacementCharacter(chara);
		}
	}

	void PlacementCharacter( Character character )
	{
		if ( character.DeadFlg == 1 ) {

			return;
		}

		int    type   = character.CharacterTypeId;
		Sprite sprite = this.characterSprite1;

		switch ( type ) {
		case 1: 
			sprite = this.characterSprite1;
			break;
		case 2:
			sprite = this.characterSprite2;
			break;
		case 3:
			sprite = this.characterSprite3;
			break;
		case 4:
			sprite = this.characterSprite4;
			break;
		case 5:
			sprite = this.characterSprite5;
			break;
		}

		string     name   = character.X + "-" + character.Y;
		GameObject button = this.field.transform.FindChild(name).gameObject;
		Image      image  = button.GetComponent<Image>();
		image.sprite = sprite;
	}

	void ResetCharacter()
	{
		int count = this.field.transform.childCount;

		for ( int i=0; i < count; i++ ) {

			GameObject button = this.field.transform.GetChild(i).gameObject;
			Image      image  = button.GetComponent<Image>();
			image.sprite = this.emptySprite;
		}
	}
	
	int GetSelectedNumber()
	{
		return PlacementScene.dont_destory_object.selected_number;
	}

	ArrayList GetPlayerList()
	{
		return PlacementScene.dont_destory_object.player_list;
	}
}
