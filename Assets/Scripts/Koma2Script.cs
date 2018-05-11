using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koma2Script : MonoBehaviour {
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
		if (stick != null) {
			if (stick.gameObject.tag == "KomaStick") {
				stick.SendMessage ("Nonrigid");
			}
		}
	}

	void OnTriggerEnter(Collider coli){
		if (coli.gameObject.tag == "Guard1") {
				stickingflag = 2;
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Koma0"||col.gameObject.tag == "KomaStick"){
			if(flagC == 2){
				if (stickingflag == 1) {
					col.gameObject.SendMessage ("Damage");
				}
			}
		}

		if (col.gameObject.tag == "Koma1") {
			if (stickingflag == 2) {
				if (fixedJoint == null){
					gameObject.AddComponent<FixedJoint> ();
					fixedJoint = GetComponent<FixedJoint> ();
					fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody> ();

					fixedJoint.enableCollision = true;

					col.gameObject.tag = "KomaStick";
					col.transform.parent = this.transform;
					stick = col.gameObject;
					stickingflag = 1;
				}
			} 
			else if (flagC == 2) {
				col.gameObject.SendMessage ("Damage");
			}
		}
	}

	void OnTriggerExit(Collider coli){
		if (coli.gameObject.tag == "Guard1") {
			stickingflag =1;
		}
	}

	public void Damage(){
		if(flagD ==1){
			komaHP--;
			int flagD = 2;
			Invoke ("FlagD", 1.2f);
			Debug.Log (3);
		}
	}

	public void FlagC(){
		flagC = 1;
		this.GetComponent<Renderer>().material=_material[0]; 
		if (stick != null) {
			if (stick.gameObject.tag == "KomaStick") {
				stick.SendMessage ("Onrigid");
			}
		}
	}

	public void Nonrigid(){
		Rigidbody rigid = (Rigidbody)this.GetComponent<Rigidbody>();
		GameObject.DestroyImmediate(rigid);
	}

	public void Onrigid(){
		//this.GetComponent<Rigidbody>();
		this.gameObject.AddComponent<Rigidbody> ();

	}

	public void FlagD(){
		int flagD = 1;
		Debug.Log (4);
	}
}
