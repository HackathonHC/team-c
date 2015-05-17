using UnityEngine;
using System.Collections;

public class CharacteParam 
{
	public Hashtable hash = new Hashtable();

	public CharacteParam ()
	{
		// hp
		Hashtable hp_param_hash = new Hashtable();
		hp_param_hash["name"] = "井上";
		hp_param_hash["hp"] = "3";
		hp_param_hash["power"] = "1";
		hp_param_hash["attack_count"] = "1";
		hp_param_hash["speed"] = "3";
		hp_param_hash["attack_range"] = "3";
		hash[1] = hp_param_hash;

		// Power
		Hashtable power_param_hash = new Hashtable();
		power_param_hash["name"] = "内藤";
		power_param_hash["hp"] = "1";
		power_param_hash["power"] = "2";
		power_param_hash["attack_count"] = "1";
		power_param_hash["speed"] = "3";
		power_param_hash["attack_range"] = "3";
		hash[2] = power_param_hash;

		// AttackCount
		Hashtable attack_count_param_hash = new Hashtable();
		attack_count_param_hash["name"] = "早田";
		attack_count_param_hash["hp"] = "1";
		attack_count_param_hash["power"] = "1";
		attack_count_param_hash["attack_count"] = "2";
		attack_count_param_hash["speed"] = "3";
		attack_count_param_hash["attack_range"] = "3";
		hash[3] = attack_count_param_hash;

		// Speed
		Hashtable speed_param_hash = new Hashtable();
		speed_param_hash["name"] = "佐藤";
		speed_param_hash["hp"] = "1";
		speed_param_hash["power"] = "1";
		speed_param_hash["attack_count"] = "1";
		speed_param_hash["speed"] = "5";
		speed_param_hash["attack_range"] = "3";
		hash[4] = speed_param_hash;

		// AttackRange
		Hashtable attack_range_param_hash = new Hashtable();
		attack_range_param_hash["name"] = "森";
		attack_range_param_hash["hp"] = "1";
		attack_range_param_hash["power"] = "1";
		attack_range_param_hash["attack_count"] = "1";
		attack_range_param_hash["speed"] = "3";
		attack_range_param_hash["attack_range"] = "5";
		hash[5] = attack_range_param_hash;
	}
}
