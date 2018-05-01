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
	//　FixedJoint
	private FixedJoint fixedJoint;
	//　外れる力
	[SerializeField]
	private float breakForce = 200f;
	//　外れる角度
	[SerializeField]
	private float breakTorque = 200f;
	//　刺さっているかどうか
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
			JudgeEnemy (col.collider);
		}
	}

	//　接触なしの場合
	void OnTriggerEnter(Collider col) {
		if (!isSticking) {
			JudgeEnemy (col);
		}
	}

	void JudgeEnemy(Collider col) {
		if (col.gameObject.tag == "Koma1") {
			if (fixedJoint == null) {
				gameObject.AddComponent<FixedJoint> ();
				fixedJoint = GetComponent<FixedJoint> ();
				fixedJoint.connectedBody = col.gameObject.GetComponent<Rigidbody> ();
				//fixedJoint.breakForce = breakForce;
				//fixedJoint.breakTorque = breakTorque;
				fixedJoint.enableCollision = true;
				isSticking = true;
				//　Rigidbodyの速度を0にし、スリープ状態にして止める
				GetComponent <Rigidbody> ().velocity = Vector3.zero;
				GetComponent <Rigidbody> ().Sleep ();
			}
		} 
	}
		//　ジョイントが解除された時に呼ばれる
		/*void OnJointBreak() {
		isSticking = false;
	}*/
}

