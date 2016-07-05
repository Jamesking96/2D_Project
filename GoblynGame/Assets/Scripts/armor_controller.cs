using UnityEngine;
using System.Collections;

public class armor_controller : MonoBehaviour {

	public enum head_armors {none, human, leather, steel};
	public enum body_armors {none, human, leather, steel};
	public enum legs_armors {none, human, leather, steel};

	int[] head_damage_reduction;
	int[] body_damage_reduction;
	int[] leg_damage_reduction;

	int[] armor_visibility_modifier; //assumes each armor set has same amount and are worth same

	head_armors head_armor;
	body_armors body_armor;
	legs_armors leg_armor;

	public int hiddenness; //higher is better

	// Use this for initialization
	void Start () {
		head_damage_reduction = new int[] { 0, 1, 2, 3};
		body_damage_reduction = new int[] { 0, 1, 2, 3 };
		leg_damage_reduction = new int[] { 0, 1, 2, 3 };
		armor_visibility_modifier = new int[] { -1, 1, 2, 3 }; //probably needs re-weighting
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Set_Head_Armor(head_armors _head_armor){
		head_armor = _head_armor;
		Calculate_Skin_Visibility ();
	}

	void Set_Body_armors(body_armors _body_armor){
		body_armor = _body_armor;
		Calculate_Skin_Visibility ();
	}

	void Set_Leg_armors(legs_armors _leg_armor){
		leg_armor = _leg_armor;
		Calculate_Skin_Visibility ();
	}

	void Calculate_Skin_Visibility(){
		hiddenness = armor_visibility_modifier [(int)head_armor] + armor_visibility_modifier [(int)body_armor] + armor_visibility_modifier [(int)leg_armor];
	}
}
