using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koma2Script : MonoBehaviour {
	public int komaHP = 2;
	public Rigidbody rb;
	public float soleMass = 1.5f;
	int flagC =1;
	int stickingflag =1;
	Vector3 latestPos;
	float speed;
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

	void Mass0 (){
		rb = this.GetComponent<Rigidbody>();
		rb.mass = 0;
	}

	public void Attack(){
		flagC = 2;
		Debug.Log ("4");
		Invoke ("FlagC", 1.2f);
	}

	void OnTriggerEnter(Collider coli){
		if (coli.gameObject.tag == "Guard1") {
			stickingflag =2;
			Debug.Log ("4");
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Koma1") {
			if (stickingflag == 2) {
				gameObject.AddComponent<FixedJoint> ();
				fixedJoint = GetComponent<FixedJoint> ();
				fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody> ();

				fixedJoint.enableCollision = true;
				//isSticking = true;

				//col.gameObject.SendMessage ("Mass0");  //質量を0にする

				Debug.Log ("1");
				//　Rigidbodyの速度を0にし、スリープ状態にして止める
				//GetComponent <Rigidbody> ().velocity = Vector3.zero;
				//GetComponent <Rigidbody> ().Sleep ();
			} 
			else if (flagC == 2) {
				col.gameObject.SendMessage ("Damage");
			}
		}

		if (flagC == 2){
			if(col.gameObject.tag == "Koma0"){
				col.gameObject.SendMessage("Damage");
			}
		}
	}

	void OnTriggerExit(Collider coli){
		if (coli.gameObject.tag == "Guard1") {
			stickingflag =1;
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
