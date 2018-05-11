using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	float power = 25.0f;
	public Vector3 direction = new Vector3 (1, 0, 1);
	Vector3 clickPosDown; 
	Vector3 clickPosUp;
	public string komaTag="Koma";
	int turn = 1;
	int flagA = 1;
	int flagB = 2;
	int flagC = 1;
	public GameObject tobasikoma;
	float distance;


	public Text onePText;
	public Text twoPText;

	// Use this for initialization
	void Start () {
		onePText.text = "1Pのターン";
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = new Ray ();
			RaycastHit hit = new RaycastHit ();
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//clickPosDown = Input.mousePosition;

			if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity)) {
				if (hit.collider.gameObject.CompareTag (komaTag + flagA.ToString ())) { 
					clickPosDown = Input.mousePosition;
					tobasikoma = hit.collider.gameObject;
					flagB = 0; //flagBがないと下のifが働かない
						if (hit.collider.gameObject.name == "King1" || hit.collider.gameObject.name == "King2") {
							power = 80.0f;
						} else {
							power = 25.0f;
						}
					}
				}
			}

		if (Input.GetMouseButtonUp (0)) {
			if (flagB == 0) {
				clickPosUp = Input.mousePosition;
				if (clickPosUp == clickPosDown) {
					return;
				}
					

				direction = (clickPosDown - clickPosUp);
				direction.z = direction.y;
				direction.y = 0;

				distance = (clickPosDown - clickPosUp).magnitude;

				if(distance > 40){
					distance = 40;
				}

				tobasikoma.GetComponent<Rigidbody> ().AddForce (direction.normalized  * power * distance);


				direction = Vector3.zero;
				distance = 0.0f;

				tobasikoma.SendMessage ("Attack");

				flagB = 1;
				turn++;
				flagA = turn % 2;
				Invoke ("Turn", 1.2f);
			}
		}
	}
		

	void Turn(){
		if (flagA == 1) {
			onePText.text = "1Pのターン";
			twoPText.text = null;
		}

		if (flagA == 0) {
			onePText.text = null;
			twoPText.text = "2Pのターン";
		}
	}

	public void FlagA(){
		flagA = flagA;
	}
}
