using UnityEngine;
using System.Collections;

public class weapon_base: MonoBehaviour {


	public bool attacking;
	public float animation_time;
	public float ignore_animation_time;
	public Vector2 force_application_amount;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D _col){
		if (_col.gameObject.layer == 9 && attacking == true) {
			Vector2 direction = ((Vector2)this.transform.position - (Vector2)_col.transform.position).normalized;
			Vector2 power = new Vector2 (2f, 2f);

			_col.GetComponent <Rigidbody2D>().AddForce (-direction + power, ForceMode2D.Impulse);
			_col.GetComponent <character_controller>().Remove_Health (damage);
			attacking = false;
		}
	}
}
