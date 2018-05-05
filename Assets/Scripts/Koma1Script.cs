using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koma1Script : MonoBehaviour {
	public int komaHP = 2;
	public Rigidbody rb;
	public float soleMass = 1.5f;
	int flagC =1;
	int stickingflag =1;

	float timer = 0.0f;
	public GameObject crack;
	private FixedJoint fixedJoint;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (komaHP == 1){
			crack.SetActive (true);
		}
			
		if (transform.position.y <= -5 || komaHP ==0){
			Destroy (this.gameObject);
		}
	}
		
	public void Attack(){
		flagC = 2;
		Invoke ("FlagC", 1.2f);
	}

	void OnTriggerEnter(Collider coli){
		if (coli.gameObject.tag == "Guard0") {
			stickingflag =2;
			Debug.Log ("4");
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Koma1"||col.gameObject.tag == "KomaStick"){
			if(flagC == 2){
				col.gameObject.SendMessage("Damage");
			}
		}

		if (col.gameObject.tag == "Koma0") {
			if (stickingflag == 2) {
				if (fixedJoint == null){
					gameObject.AddComponent<FixedJoint> ();
					fixedJoint = GetComponent<FixedJoint> ();
					fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody> ();

					fixedJoint.enableCollision = true;
					col.gameObject.GetComponent<Rigidbody> ().useGravity = false;
					col.gameObject.tag = "KomaStick";
				}
			} 
			else if (flagC == 2) {
					col.gameObject.SendMessage ("Damage");
			}
		}
	}

	void OnTriggerExit(Collider coli){
		if (coli.gameObject.tag == "Guard0") {
			stickingflag =1;
		}
	}

	public void Damage(){
		komaHP--;
	}

	public void FlagC(){
		flagC = 1;
	}
}
