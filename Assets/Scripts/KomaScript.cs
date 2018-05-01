using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KomaScript : MonoBehaviour {
	public int komaHP = 1;
	public Text HPLabel;
	public  float solemass = 1.0f;
	public Rigidbody rb;
	public int flagC = 1;
	public float soleMass = 1.0f;



	// Use this for initialization
	void Start () {
		/*int aCount;
		aCount = guardScript.FlagC;
		Debug.Log(aCount);*/
	}
	
	// Update is called once per frame
	void Update () {
		//HPLabel.text = "HP:" + komaHP.ToString ();
		if (transform.position.y <= -10 || komaHP ==0){
			Destroy (this.gameObject);
		}

		/*if(flagC == 1){
			rb = this.GetComponent<Rigidbody>();
			rb.mass = soleMass;
		}
		if(flagC == 2){
			rb = this.GetComponent<Rigidbody>();
			rb.mass = 0;
		}*/
	}

	void Mass0 (){
		rb = this.GetComponent<Rigidbody>();
		rb.mass = 0;
	}
}
