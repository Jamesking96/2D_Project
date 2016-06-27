﻿using UnityEngine;
using System.Collections;

public class player_controller : character_controller {

	// Use this for initialization
	void Start () {
		movement = GetComponent <character_movement> ();
		animator = GetComponent <Animator> ();
		weapon = GetComponentInChildren <weapon_base> ();
	}
	
	// Update is called once per frame
	void Update () {
		Handle_User_Input ();
	}

	void Handle_User_Input(){
		if(Input.GetKey (KeyCode.LeftArrow)){
			movement.Set_Direction (-1);
		}
		else if(Input.GetKey (KeyCode.RightArrow)){
			movement.Set_Direction (1);
		}
		else{
			movement.Set_Direction (0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			movement.Jump ();
		}

		if(Input.GetKeyDown (KeyCode.A)){
			if (weapon.attacking == false) {
				Attack ();
			}
		}
	}

	void Attack(){
		animator.SetBool ("attacking", true);
		weapon.attacking = true;
		StartCoroutine (Stop_Attack (weapon.animation_time));
	}

	IEnumerator Stop_Attack(float wait_time){
		yield return new WaitForSeconds (wait_time);
		animator.SetBool ("attacking", false);
		weapon.attacking = false;
	}


}
