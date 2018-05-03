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

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		speed = ((this.transform.position - latestPos) / Time.deltaTime).magnitude;
		latestPos = this.transform.position; 

		if (transform.position.y <= -5 || komaHP ==0){
			Destroy (this.gameObject);
		}

		if(speed < 0.00005f){
			flagC = 1;
		}
	}
		
	void Mass0 (){
		rb = this.GetComponent<Rigidbody>();
		rb.mass = 0;
	}

	void Attack(){
		flagC = 2;
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Koma0"||col.gameObject.tag == "Koma1"){
			//if (flagC == 2) {
				col.gameObject.SendMessage("Damage");
			Debug.Log ("4");
			//}
		}
	}

	void Dmage(){
		komaHP--;
	}
}
