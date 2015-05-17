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
	private Button modeBtn;

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
	private int mode          = 1;		// Attack=1, Move=2
	private int dropOutCount  = 0;
	private Character selectCharacter = null;

	
	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayBGM("bgm");

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

		modeBtn.onClick.AsObservable().Subscribe(_ =>ChangeMode());

		this.DisplayBlind(this.playingNumber);
		this.InitPlayerInfo();
		this.ResetCharacter();
		this.SetupPlayers(this.GetPlayerList());
		this.UpdateGameInfo();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void SlectField (int x, int y) {

		int       index         = this.GetCurrentPlayerListIndex();
		ArrayList players       = this.GetPlayerList();
		ArrayList hitCharacters = this.GetCharactersInPlace(x, y, (Player)players[index]);

		if ( hitCharacters.Count > 0 ) {

			this.ResetCharacter();
			this.SetupPlayers (this.GetPlayerList());

			foreach ( Character chara in hitCharacters ) {

				if ( this.mode == 1 ) {
					ArrayList names = this.GetEnableRangeNames(chara, chara.AttackRange);
					this.DisplayAttackRange(names);
				}
				else if ( this.mode == 2 ) {
					ArrayList names = this.GetEnableRangeNames(chara, chara.MoveRange);
					this.DisplayMoveRange(names);
				}

				this.selectCharacter = chara;
			}

			return;
		}

		GameObject 		obj    = this.GetCharacterButton(x, y);
		CharacterButton button = obj.GetComponent<CharacterButton>();
		
		if ( button.attackRangeEnable == true ) {
			AudioManager.Instance.PlaySE("hit");
			this.attack(this.selectCharacter, x, y);
			this.ChangePlayer();
		}
		else if ( button.moveRangeEnable == true ) {
			AudioManager.Instance.PlaySE("move");
			this.move(this.selectCharacter, x, y);
			this.ChangePlayer ();
		}
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

		if ( this.dropOutCount >= max ) {

			Application.LoadLevel("ResultScene");
			return;
		}

		this.playingNumber++;

		if ( this.playingNumber > max ) {

			this.playingNumber = 1;
		}

		this.DisplayBlind(this.playingNumber);
		this.ResetCharacter();
		this.SetupPlayers (this.GetPlayerList());
		this.UpdateGameInfo();
	}

	void DisplayBlind( int number )
	{
		GameObject blind = (GameObject)Instantiate(this.blind, this.transform.position, this.transform.rotation);
		blind.transform.parent = this.transform;

		Text text = blind.GetComponentInChildren<Text>();
		string name = "";
		if (number == 1) {
			name = "一";
		} else if (number == 2) {
			name = "二";
		} else if (number == 3) {
			name = "三";
		} else if (number == 4) {
			name = "四";
		}
		text.text = "忍者 " + name;
	}

	void SetupPlayers( ArrayList playerList )
	{
		int    index  = this.GetCurrentPlayerListIndex();
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

		GameObject button = this.GetCharacterButton(character.X, character.Y);
		Image      image  = button.GetComponent<Image>();
		image.sprite = sprite;
	}
	
	void ResetCharacter()
	{
		int count = this.field.transform.childCount;

		for ( int i=0; i < count; i++ ) {

			GameObject  	obj    = this.field.transform.GetChild(i).gameObject;
			CharacterButton button = obj.GetComponent<CharacterButton>();

			button.Reset();

			Image image  = obj.GetComponent<Image>();
			image.sprite = this.emptySprite;
			image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	GameObject GetCharacterButton( int x, int y )
	{
		string name = x + "-" + y;

		return this.GetCharacterButton(name);
	}

	GameObject GetCharacterButton( string name )
	{
		Transform t = this.field.transform.FindChild(name);

		if ( t == null ) {

			return null;
		}

		return t.gameObject;
	}

	int GetSelectedNumber()
	{
		return PlacementScene.dont_destory_object.selected_number;
	}

	ArrayList GetPlayerList()
	{
		return PlacementScene.dont_destory_object.player_list;
	}

	int GetCurrentPlayerListIndex()
	{
		return this.playingNumber - 1;
	}

	ArrayList GetCharactersInPlace( int x, int y, Player player )
	{
		ArrayList hitCharacters = new ArrayList();

		foreach ( Character chara in player.deck.characters ) {
			
			if ( chara.X != x || chara.Y != y ) {
				
				continue;
			}

			hitCharacters.Add(chara);
		}

		return hitCharacters;
	}

	ArrayList GetEnableRangeNames( Character chara, int range )
	{
		int minX  = chara.X - range;
		int maxX  = chara.X + range;
		int minY  = chara.Y - range;
		int maxY  = chara.Y + range;

		if ( minX < 1 ) {

			minX = 1;
		}
		else if ( maxX >= 5 ) {

			maxX = 5;
		}

		if ( minY < 1 ) {

			minY = 1;
		}
		else if ( maxY >= 7 ) {

			maxY = 7;
		}

		ArrayList points = new ArrayList();

		for ( int x=minX; x <= maxX; x++ ) {

			if ( x == chara.X ) {

				continue;
			}

			string name = x + "-" + chara.Y;
			points.Add(name);
		}

		for ( int y=minY; y <= maxY; y++ ) {

			if ( y == chara.Y ) {

				continue;
			}

			string name = chara.X + "-" + y;
			points.Add(name);
		}

		return points;
	}

	void DisplayAttackRange( ArrayList names ) 
	{
		foreach ( string name in names ) {

			GameObject      obj    = this.GetCharacterButton(name);
			CharacterButton button = obj.GetComponent<CharacterButton>();

			if ( button == null ) {

				continue;
			}

			button.attackRangeEnable = true;

			Image image = obj.GetComponent<Image>();
			image.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);

			Debug.Log("Display  "+ name);
		}
	}

	void DisplayMoveRange( ArrayList names ) 
	{
		foreach ( string name in names ) {
			
			GameObject obj = this.GetCharacterButton(name);

			if ( obj == null ) {

				continue;
			}

			CharacterButton button = obj.GetComponent<CharacterButton>();
			
			if ( button == null ) {
				
				continue;
			}
			
			button.moveRangeEnable = true;
			
			Image image = obj.GetComponent<Image>();
			image.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);			
		}
	}

	void attack( Character attacker, int x, int y )
	{
		foreach ( Player player in this.GetPlayerList() ) {

			if ( player.Id == this.playingNumber ) {

				continue;
			}

			ArrayList characters = this.GetCharactersInPlace(x, y, player);

			foreach ( Character chara in characters ) {

				if ( chara.DeadFlg == 1 ) {

					continue;
				}

				chara.Damage(attacker.AttackCount);
			}

			if ( player.IsDropOut() == true ) {

				int ranking = this.GetSelectedNumber() - this.dropOutCount;
				player.ranking = ranking;

				this.dropOutCount++;
			}

		}
	}

	void move( Character character, int x, int y )
	{
		if ( character.DeadFlg == 1 ) {

			return;
		}

		character.X = x;
		character.Y = y;
	}

	void ChangeMode()
	{
		AudioManager.Instance.PlaySE("submit");
		string text = "";

		if ( this.mode == 1 ) {

			this.mode = 2;
			text      = "MOVE";

		}
		else {

			this.mode = 1;
			text      = "ATTACK";
		}

		Text title = this.modeBtn.GetComponentInChildren<Text>();
		title.text = text;

		this.ResetCharacter();
		this.SetupPlayers(this.GetPlayerList());
	}

	void UpdateGameInfo()
	{
		ArrayList players = this.GetPlayerList();

		for( int i=0; i < players.Count; i++ ) {

			Player 	   player = (Player)players[i];
			PlayerDeck deck   = player.deck;

			GameObject info = this.playerInfo[i];
			GameObject obj  = info.transform.FindChild("Character Num").gameObject;
			Text text = obj.GetComponentInChildren<Text>();
			text.text = "残り " + deck.GetAliveCount();

			if ( deck.GetAliveCount() <= 1 ) {

				text.color = new Color(1.0f, 0, 0);
			}
		}
	}
}
