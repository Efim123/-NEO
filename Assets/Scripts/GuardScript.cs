using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour {

	enum Mode {
		collision,
		trigger
	};

	//　モード
	[SerializeField]
	private Mode mode;
	private FixedJoint fixedJoint;
	[SerializeField]
	private float breakForce = 200f;
	[SerializeField]
	private float breakTorque = 200f;
	private bool isSticking;

	void Start() {
		if(mode == Mode.collision) {
			GetComponentInChildren<Collider>().isTrigger = false;
		} else if(mode == Mode.trigger) {
			GetComponentInChildren<Collider>().isTrigger = true;
		}
	}

	//　衝突ありの場合
	void OnCollisionEnter(Collision col) {
		if (!isSticking) {
			JudgeOther (col.collider);
		}
	}

	//　接触なしの場合
	void OnTriggerEnter(Collider col) {
		if (!isSticking) {
			JudgeOther (col);
		}
	}

	void JudgeOther(Collider col) {
		if (col.gameObject.tag == "Koma0"||col.gameObject.tag == "Koma1") {
				if (fixedJoint == null) {
				gameObject.AddComponent<FixedJoint> ();
				fixedJoint = GetComponent<FixedJoint> ();
				fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody> ();

				fixedJoint.enableCollision = true;
				isSticking = true;

				 //質量を0にする

				Debug.Log ("1");
				//　Rigidbodyの速度を0にし、スリープ状態にして止める
				GetComponent <Rigidbody> ().velocity = Vector3.zero;
				GetComponent <Rigidbody> ().Sleep ();
			}
		}
	}
		//　ジョイントが解除された時に呼ばれる
	void OnJointBreak() {
		isSticking = false;
	}
}

