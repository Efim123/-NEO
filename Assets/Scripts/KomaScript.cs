using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KomaScript : MonoBehaviour {
	public int komaHP = 2;
	public Rigidbody rb;
	public float soleMass = 1.5f;
	int flagC =1;
	Vector3 latestPos;
	float speed;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -5 || komaHP ==0){
			Destroy (this.gameObject);
		}
	}
		
	void Mass0 (){
		rb = this.GetComponent<Rigidbody>();
		rb.mass = 0;
	}

	public void Attack(){
		flagC = 2;
		Debug.Log ("4");
		Invoke ("FlagC", 2.0f);
	}

	void OnCollisionEnter(Collision col) {
		if (flagC == 2) {
			if(col.gameObject.tag == "Koma0"||col.gameObject.tag == "Koma1"){
				col.gameObject.SendMessage("Damage");
			}
		}
	}

	public void Damage(){
		komaHP--;
		Debug.Log ("6");
	}

	public void FlagC(){
		flagC = 1;
	}
}
