using UnityEngine;
using System.Collections;

public class weapon_controller : MonoBehaviour {

	public enum weapons {hand, club, spiked_club, dagger, short_sword, sword, long_sword, bow, old_bow};
	public weapons weapon;

	float[] weapon_damage;
	float[] weapon_range;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
