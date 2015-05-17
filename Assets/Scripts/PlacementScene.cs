using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class PlacementScene : MonoBehaviour
{
	[SerializeField]
	private Button resetBtn;
	[SerializeField]
	private Button submitBtn;

	[SerializeField]
	private Button CharacterRectBtn1;
	[SerializeField]
	private Button CharacterRectBtn2;
	[SerializeField]
	private Button CharacterRectBtn3;
	[SerializeField]
	private Button CharacterRectBtn4;
	[SerializeField]
	private Button CharacterRectBtn5;

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
	
	public Sprite character_image1;
	public Sprite character_image2;
	public Sprite character_image3;
	public Sprite character_image4;
	public Sprite character_image5;
	public Sprite empty_character_image;

	public Sprite character_stand_image1;
	public Sprite character_stand_image2;
	public Sprite character_stand_image3;
	public Sprite character_stand_image4;
	public Sprite character_stand_image5;
	public Sprite empty_character_stand_image;

	private GameObject character_list_black;
	private GameObject field_black;
	private GameObject character_spec;

	private int select_character_id;

	public static  DontDestroyObjecter dont_destory_object;
	private int player_id;

	private PlayerDeck deck;

	private ArrayList player_list = new ArrayList();
	
	const int select_count = 3;

	void Awake ()
	{
		resetBtn.onClick.AsObservable().Subscribe(_ =>reset());
		submitBtn.onClick.AsObservable().Subscribe(_ =>submit());

		CharacterRectBtn1.onClick.AsObservable().Subscribe(_ =>SelectCharacter(1));
		CharacterRectBtn2.onClick.AsObservable().Subscribe(_ =>SelectCharacter(2));
		CharacterRectBtn3.onClick.AsObservable().Subscribe(_ =>SelectCharacter(3));
		CharacterRectBtn4.onClick.AsObservable().Subscribe(_ =>SelectCharacter(4));
		CharacterRectBtn5.onClick.AsObservable().Subscribe(_ =>SelectCharacter(5));
		
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
		DontDestroyOnLoad(this);
	}


	// Use this for initialization
	void Start () {
		if (player_id == 0)
		{
			player_id = 1;
		} else if (player_id == 1) {
			player_id = 2;
		} else if (player_id == 2) {
			player_id = 3;
		} else if (player_id == 3) {
			player_id = 4;
		}
		deck = new PlayerDeck(player_id);

		GameObject player_name = GameObject.Find("Player Name");
		Text player_name_text = player_name.GetComponent<Text>();
		player_name_text.text = "プレイヤー" + player_id;

		character_list_black = GameObject.Find("Character List Black Out");
		character_list_black.SetActiveRecursively(false);

		character_spec = GameObject.Find("Character Spec");
		character_spec.SetActiveRecursively(false);

		field_black = GameObject.Find("Field Black Out");
		field_black.SetActiveRecursively(true);

		submitBtn.enabled = false;
		SetRectBtnEnable(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SlectField (int x, int y) {
		Debug.Log("SlectField :" + x.ToString() + y.ToString());

		SetRectBtnEnable(false); 
		character_list_black.SetActiveRecursively(false);
		field_black.SetActiveRecursively(true);

		Sprite rect_image = character_image1;
		if (select_character_id == 1)
		{
			rect_image = character_image1;
		} else if (select_character_id == 2) {
			rect_image = character_image2;
		} else if (select_character_id == 3) {
			rect_image = character_image3;
		} else if (select_character_id == 4) {
			rect_image = character_image4;
		} else if (select_character_id == 5) {
			rect_image = character_image5;
		}

		GameObject field_rect = GameObject.Find(x + "-" + y);
		Image field_rect_image = field_rect.GetComponent<Image>();
		field_rect_image.sprite = rect_image;

		Character charcter= new Character(select_character_id);
		charcter.X = x;
		charcter.Y = y;
		charcter.CharacterTypeId = select_character_id;
		deck.characters.Add(charcter);

		if (deck.characters.Count == select_count)
		{
			character_list_black.SetActiveRecursively(true);
			field_black.SetActiveRecursively(true);
			SetRectBtnEnable(false); 

			submitBtn.enabled = true;
		}
	}

	void SelectCharacter (int characterid) 
	{
		Debug.Log("SelectCharacter :" + characterid.ToString());

		SetRectBtnEnable(true); 
		character_spec.SetActiveRecursively(true);

		field_black.SetActiveRecursively(false);
		select_character_id = characterid;

		Hashtable select_caracter_param = (Hashtable)new CharacteParam().hash[characterid];

		GameObject character_name = GameObject.Find("Character Name");
		Text character_name_text = character_name.GetComponent<Text>();
		character_name_text.text = (string)select_caracter_param["name"];

		GameObject character_hp = GameObject.Find("Character Hp");
		Text characterer_hp_text = character_hp.GetComponent<Text>();
		characterer_hp_text.text = (string)select_caracter_param["hp"];

		GameObject character_power = GameObject.Find("Character Power");
		Text character_power_text = character_power.GetComponent<Text>();
		character_power_text.text = (string)select_caracter_param["power"];

		GameObject character_speed = GameObject.Find("Character Speed");
		Text character_speed_text = character_speed.GetComponent<Text>();
		character_speed_text.text = (string)select_caracter_param["speed"];

		GameObject character_attack_count = GameObject.Find("Character Attck Count");
		Text character_attack_count_text = character_attack_count.GetComponent<Text>();
		character_attack_count_text.text = (string)select_caracter_param["attack_count"];

		GameObject character_attack_range = GameObject.Find("Character Attack Range");
		Text character_attack_range_text = character_attack_range.GetComponent<Text>();
		character_attack_range_text.text = (string)select_caracter_param["attack_range"];

		Sprite stand_image = character_stand_image1;
		if (select_character_id == 1)
		{
			stand_image = character_stand_image1;
		} else if (select_character_id == 2) {
			stand_image = character_stand_image2;
		} else if (select_character_id == 3) {
			stand_image = character_stand_image3;
		} else if (select_character_id == 4) {
			stand_image = character_stand_image4;
		} else if (select_character_id == 5) {
			stand_image = character_stand_image5;
		}
		
		GameObject caracter_stand = GameObject.Find("Character Image");
		Image caracter_stand_image = caracter_stand.GetComponent<Image>();
		caracter_stand_image.sprite = stand_image;
	}

	void reset () 
	{
		Debug.Log("reset!");

		foreach (Character caracter in deck.characters)
		{
			GameObject field_rect = GameObject.Find(caracter.X + "-" + caracter.Y);
			Image field_rect_image = field_rect.GetComponent<Image>();
			field_rect_image.sprite = empty_character_image;
		}
		character_list_black.SetActiveRecursively(false);
		field_black.SetActiveRecursively(true);
		SetCharacteSelectBtnEnable(true);
		SetRectBtnEnable(false);
		deck.Clear();
		submitBtn.enabled = false;
	}

	void submit () 
	{
		Debug.Log("submit!!");

		Player player = new Player(player_id, deck);
		player_list.Add(player);
		Debug.Log("player_list count :"+player_list.Count);

		int selected_number = NumberSelectScene.selectedNumber;

		if (player_id >= selected_number)
		{
			dont_destory_object = new DontDestroyObjecter(selected_number, player_list);
			Application.LoadLevel("GameScene");
		} else {
			foreach (Character caracter in deck.characters)
			{
				GameObject field_rect = GameObject.Find(caracter.X + "-" + caracter.Y);
				Image field_rect_image = field_rect.GetComponent<Image>();
				field_rect_image.sprite = empty_character_image;
			}
			if (player_id == 0)
			{
				player_id = 1;
			} else if (player_id == 1) {
				player_id = 2;
			} else if (player_id == 2) {
				player_id = 3;
			} else if (player_id == 3) {
				player_id = 4;
			}
			deck = new PlayerDeck(player_id);
			
			GameObject player_name = GameObject.Find("Player Name");
			Text player_name_text = player_name.GetComponent<Text>();
			player_name_text.text = "プレイヤー" + player_id;
			
			character_list_black.SetActiveRecursively(false);			
			character_spec.SetActiveRecursively(false);
			field_black.SetActiveRecursively(true);
			
			submitBtn.enabled = false;
			SetRectBtnEnable(false);
		}
	}

	private void SetCharacteSelectBtnEnable (bool b) 
	{
		CharacterRectBtn1.enabled = b;
		CharacterRectBtn2.enabled = b;
		CharacterRectBtn3.enabled = b;
		CharacterRectBtn4.enabled = b;
		CharacterRectBtn5.enabled = b;
	}

	private void SetRectBtnEnable (bool b) 
	{
		rectBtn1_1.enabled = b;
		rectBtn1_2.enabled = b;
		rectBtn1_3.enabled = b;
		rectBtn1_4.enabled = b;
		rectBtn1_5.enabled = b;
		rectBtn1_6.enabled = b;
		rectBtn1_7.enabled = b;
		rectBtn2_1.enabled = b;
		rectBtn2_2.enabled = b;
		rectBtn2_3.enabled = b;
		rectBtn2_4.enabled = b;
		rectBtn2_5.enabled = b;
		rectBtn2_6.enabled = b;
		rectBtn2_7.enabled = b;
		rectBtn3_1.enabled = b;
		rectBtn3_2.enabled = b;
		rectBtn3_3.enabled = b;
		rectBtn3_4.enabled = b;
		rectBtn3_5.enabled = b;
		rectBtn3_6.enabled = b;
		rectBtn3_7.enabled = b;
		rectBtn4_1.enabled = b;
		rectBtn4_2.enabled = b;
		rectBtn4_3.enabled = b;
		rectBtn4_4.enabled = b;
		rectBtn4_5.enabled = b;
		rectBtn4_6.enabled = b;
		rectBtn4_7.enabled = b;
		rectBtn5_1.enabled = b;
		rectBtn5_2.enabled = b;
		rectBtn5_3.enabled = b;
		rectBtn5_4.enabled = b;
		rectBtn5_5.enabled = b;
		rectBtn5_6.enabled = b;
		rectBtn5_7.enabled = b;
	}

}
