using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KomaScript : MonoBehaviour {
	public int komaHP = 1;
	public Text HPLabel;
	public Rigidbody rb;
	public float soleMass = 1.5f;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//HPLabel.text = "HP:" + komaHP.ToString ();
		if (transform.position.y <= -5 || komaHP ==0){
			Destroy (this.gameObject);
		}
	}
		
	void Mass0 (){
		rb = this.GetComponent<Rigidbody>();
		rb.mass = 0;
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.tag == "Koma0"||col.gameObject.tag == "Koma1"){
			rb = this.GetComponent<Rigidbody>();
			rb.mass = soleMass; //⇦ここでおかしくなる
			Debug.Log("2");
		}
	}

	/*void OnCollisionStay(Collision col) {
		if(col.gameObject.tag == "Guard"){
			GameObject.DestroyImmediate(FixedJoint);
			rb = this.GetComponent<Rigidbody>();
			rb.mass = soleMass; 
			Debug.Log("3");
		}
	}*/
}
