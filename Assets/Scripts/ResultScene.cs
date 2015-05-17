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
		AudioManager.Instance.PlayBGM("default_bgm");
		ContinueBtn.onClick.AsObservable().Subscribe(_ =>Continue());

		var player_list = (ArrayList)PlacementScene.dont_destory_object.player_list;
		Hashtable ranking_hash = new Hashtable();
		foreach (Player player in player_list) 
		{
			ranking_hash[player.ranking] = player.Id;
		}

		for (int i=1; i <= ranking_hash.Count; i++)
		{
			GameObject player_name = GameObject.Find("Text-RankName" + i);
			Text player_name_text = player_name.GetComponent<Text>();

			int playerId = (int)ranking_hash[i];
			string name = "";
			if (playerId == 1) {
				name = "一";
			} else if (playerId == 2) {
				name = "二";
			} else if (playerId == 3) {
				name = "三";
			} else if (playerId == 4) {
				name = "四";
			}
			player_name_text.text = "忍者" + name;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Continue()
	{
		AudioManager.Instance.PlaySE("submit");
		// Back to title or NumberSelectScene.
		Application.LoadLevel("NumberSelectScene");
	}
}
