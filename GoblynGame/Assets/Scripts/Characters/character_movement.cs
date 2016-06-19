using UnityEngine;
using System.Collections;

public class character_movement : MonoBehaviour {
	Rigidbody2D rigidbody;
	BoxCollider2D collider;

	float current_x_speed;
	public float max_speed;
	public float acceleration;
	public float deceleration;

	public float jump_speed;

	bool can_jump_key;

	int direction;
	int look_direction; //not quite happy having 2 directions but... yeah.

	void Start(){
		rigidbody = GetComponent <Rigidbody2D> ();
		collider = GetComponent <BoxCollider2D> ();
	}

	void Update(){
		Move ();
	}

	public void Set_Direction(int _direction){
		direction = _direction;
		Flip_And_Position_Sprite (_direction);
	}

	void Flip_And_Position_Sprite(int _direction){
		if (_direction != 0 && _direction != look_direction) {

			look_direction = _direction;
			Vector3 new_position = this.transform.position;
			Vector3 new_scale = this.transform.localScale;

			if (look_direction == -1) {
				new_scale.x = -Mathf.Abs (new_scale.x);
				new_position.x += collider.bounds.extents.x;
			}
			else{
				new_scale.x = Mathf.Abs (new_scale.x);
				new_position.x -= collider.bounds.extents.x;
			}
			this.transform.localScale = new_scale;
			this.transform.position = new_position;
		}
	}

	public void Jump(){
		if(Is_Grounded ()){
			Vector2 velocity = rigidbody.velocity;
			velocity.y = jump_speed;
			rigidbody.velocity = velocity;
		}
	}

	void Move(){
		Calculate_X_Speed ();
		Vector2 current_velocity = rigidbody.velocity;
		current_velocity.x = current_x_speed;
		rigidbody.velocity = current_velocity;
	}

	void Calculate_X_Speed(){
		if(direction == 1){
			current_x_speed = Mathf.Lerp (current_x_speed, max_speed, acceleration);
		}
		else if(direction == -1){
			current_x_speed = Mathf.Lerp (current_x_speed, -max_speed, acceleration);

		}
		else{
			current_x_speed = Mathf.Lerp (current_x_speed, 0, deceleration);
		}
	}

	bool Is_Grounded(){
		bool is_grounded = false;

		Vector3 left, middle, right;
		left = middle = right = this.transform.position;

		middle.x += collider.bounds.extents.x;
		right.x += collider.bounds.extents.x * 2;

		collider.enabled = false;

		if (Physics2D.Raycast (left, -Vector3.up, 0.1f) ||
			Physics2D.Raycast (middle, -Vector3.up, 01f) ||
			Physics2D.Raycast (right, -Vector3.up, 01f)){
			is_grounded = true;
		}

		collider.enabled = true;
		return is_grounded;
	}


}
