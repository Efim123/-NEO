using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koma1Script : MonoBehaviour {
	public int komaHP = 2;
	public Rigidbody rb;
	public float soleMass = 1.5f;
	int flagC =1;
	int flagD =1;

	int stickingflag =1;

	float timer = 0.0f;
	public GameObject crack;
	private FixedJoint fixedJoint;
	private GameObject stick;

	public Material[] _material;

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().material=_material[0]; 
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

		if (this.gameObject.tag == "KomaStick") {
			this.GetComponent<Renderer>().material=_material[2]; 
		}

	}
		
	public void Attack(){
		flagC = 2;
		this.GetComponent<Renderer>().material=_material[1]; 
		Invoke ("FlagC", 1.2f);
		if(stick != null){
			if (stick.gameObject.tag == "KomaStick") {
				stick.SendMessage ("Nonrigid");
			}
		}
	}

	void OnTriggerEnter(Collider coli){
		if (coli.gameObject.tag == "Guard0") {
				stickingflag = 2;
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Koma1"||col.gameObject.tag == "KomaStick"){
			if(flagC == 2){
				if (stickingflag == 1) {
					col.gameObject.SendMessage ("Damage");
				}
			}
		}

		if (col.gameObject.tag == "Koma0") {
			if (stickingflag == 2) {
				if (fixedJoint == null){
					gameObject.AddComponent<FixedJoint> ();
					fixedJoint = GetComponent<FixedJoint> ();
					fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody> ();

					fixedJoint.enableCollision = true;

					col.gameObject.tag = "KomaStick";
					col.transform.parent = this.transform;
					stickingflag =1;
					stick = col.gameObject;
				}
			} 
			else if (flagC == 2) {
					col.gameObject.SendMessage ("Damage");
			}
		}
	}

	void OnTriggerStay(Collider coli){
		if(flagC ==2){
		if (coli.gameObject.tag == "KomaStick") {
				if (coli.GetComponent<Rigidbody> ()) {
					Rigidbody rigid = (Rigidbody)this.GetComponent<Rigidbody> ();
					GameObject.DestroyImmediate (rigid);
				}
			}
		}
	}

	void OnTriggerExit(Collider coli){
		if (coli.gameObject.tag == "Guard0") {
			stickingflag =1;
		}
	}

	public void Damage(){
		if(flagD ==1){
			komaHP--;
			int flagD = 2;
			Invoke ("FlagD", 1.2f);
		}
	}

	public void FlagC(){
		this.GetComponent<Renderer>().material=_material[0]; 
		flagC = 1;
		Debug.Log (2);
		if(stick != null){
			if (stick.gameObject.tag == "KomaStick") {
				stick.SendMessage ("Onrigid");
				Debug.Log (3);
			}
		}
	}

	public void Nonrigid(){
		Rigidbody rigid = (Rigidbody)this.GetComponent<Rigidbody>();
		GameObject.DestroyImmediate(rigid);
	}

	public void Onrigid(){
		//Rigidbody rigid = (Rigidbody)this.GetComponent<Rigidbody>();
		this.gameObject.AddComponent<Rigidbody> ();
		Debug.Log (4);
	}

	public void FlagD(){
		int flagD = 1;
	}
}
