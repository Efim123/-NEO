using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingScript : MonoBehaviour {
	public int komaHP = 5;
	public Text HPLabel;
	public GameObject result;
	int flagC =1;

	public Material[] _material; 

	void Start () {
		this.GetComponent<Renderer>().material=_material[0];
	}

	// Update is called once per frame
	void Update () {
		HPLabel.text = "HP:" + komaHP.ToString ();
		if (transform.position.y <= -5 || komaHP == 0) {
			Invoke ("Retry", 0.5f);
		}
	}

	void Retry(){
		result.SetActive (true);
		Destroy (this.gameObject);
	}

	public void Attack(){
		flagC = 2;
		this.GetComponent<Renderer>().material=_material[1];
		Invoke ("FlagC", 1.2f);
	}

	void OnCollisionEnter(Collision col) {
		if (flagC == 2) {
			if(col.gameObject.tag == "Koma0"||col.gameObject.tag == "Koma1"||col.gameObject.tag == "KomaStick"){
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
		this.GetComponent<Renderer>().material=_material[0];
	}
}
