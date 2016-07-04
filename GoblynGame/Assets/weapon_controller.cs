using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class weapon_controller : MonoBehaviour {

	public enum weapons {hand, club, spiked_club, dagger, short_sword, sword, long_sword, bow, old_bow};
	public enum attack_methods {melee, ranged};

	attack_methods[] attack_types;
	float[] attack_ranges;
	float[] damage_amounts;
	float[] attack_lengths;

	public weapons weapon;
	public attack_methods attack_method;

	public float range;
	public float damage;
	public float attack_length;

	CircleCollider2D collider;

	float enemies_in_range;

	public List<character_controller> enemies;

	// Use this for initialization
	void Start () {
		attack_types = new attack_methods[] {
			attack_methods.melee, attack_methods.melee, attack_methods.melee, attack_methods.melee, attack_methods.melee, 
			attack_methods.melee, attack_methods.melee, attack_methods.ranged, attack_methods.ranged
		};
		attack_ranges = new float[] {1, 2, 3, 4, 5, 6, 7, 8 };
		damage_amounts = new float[] { 9, 10, 11, 12, 13, 14, 15, 16 };
		attack_lengths = new float[] { 1, 1, 1, 1, 1, 1, 1, 1 };

		collider = GetComponent <CircleCollider2D> ();

		Set_Weapon ();

		enemies = new List<character_controller> ();

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Set_Weapon(){
		attack_method = attack_types [(int)weapon];
		range = attack_ranges [(int)weapon];
		damage = damage_amounts [(int)weapon];
		collider.radius = range;
		attack_length = attack_lengths [(int)weapon];
	}

	public void Attack(){
		for(int i = 0; i < enemies.Count; i++){
			enemies [i].Remove_Health (1);
		}
	}

	void OnTriggerEnter2D(Collider2D _col){
		if(_col.gameObject.layer == 9){
			enemies_in_range++;
			enemies.Add (_col.gameObject.GetComponent <character_controller>());
		}
	}

	void OnTriggerExit2D(Collider2D _col){
		if(_col.gameObject.layer == 9){
			enemies_in_range--;
			for(int i = 0; i < enemies.Count; i++){
				if(enemies[i] == _col.gameObject.GetComponent <character_controller>()){
					enemies.Remove (_col.gameObject.GetComponent <character_controller> ());
				}
			}
		}
	}
}
