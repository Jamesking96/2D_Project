using UnityEngine;
using System.Collections;

public class character_controller : MonoBehaviour {

	public character_movement movement;
	public Animator animator;
	public int health;
	public weapon_controller weapon;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Add_Health(int amount){
		health += amount;
	}

	public void Remove_Health(int amount){
		health -= amount;
		Health_Check ();
	}

	public int Get_Health(){
		return health;
	}

	public void Health_Check(){
		if(health <= 0){
			Die ();
		}
	}

	void Die(){
		Destroy (this.gameObject);
	}
		
}
