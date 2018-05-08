using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
	private Image arrow;
	private RectTransform rectTransform;
	private Vector3 startPos;
	private Vector3 currentPos;
	int flagA = 1;
	int flagB = 2;
	int turn = 1;

	void Awake()
	{
		arrow = GetComponent<Image>();
		rectTransform = GetComponent<RectTransform>();
	}

	void Start()
	{
		arrow.enabled = false;
	}

	void Update()
	{
		// ドラッグ開始
		if (Input.GetMouseButtonDown(0))
		{

			Ray ray = new Ray ();
			RaycastHit hit = new RaycastHit ();
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray.origin, ray.direction, out hit, Mathf.Infinity)) {
				if (hit.collider.gameObject.CompareTag ("Koma" + flagA.ToString ())) { 
					
					// Imageを有効にして矢印を見えるように
					arrow.enabled = true;

					// ドラッグ開始位置を保存
					startPos = Input.mousePosition;
					//startPos = new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.z);
					Debug.Log(startPos);

					// 位置を調整
					rectTransform.position = startPos;

					flagB = 1; 
				}
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			if (flagB == 1) {
				if (startPos == currentPos) {
					return;
				}
			}
		}

			

		// ドラッグ中
		if (Input.GetMouseButton(0))
		{
			if (flagB == 1) {

				// 現在のマウス位置
				currentPos = Input.mousePosition;

				// 長さを調整
				float distance = Vector2.Distance (startPos, currentPos) * 2;
				if (distance >= 40) {
					distance = 40;
				}

				rectTransform.sizeDelta = new Vector2 (100, distance*3.75f);

				// 角度を調整
				float angle = Mathf.Atan2 (currentPos.y - startPos.y, currentPos.x - startPos.x);
				// RadianからDegreeに変換
				angle *= Mathf.Rad2Deg;
				// 矢印が下向きだったため...
				// 矢印の向きに合わせて調整
				angle -= 90f;
				// 回転
				rectTransform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
			}
		}

		// ドラッグ終了
		if (Input.GetMouseButtonUp(0))
		{
			if (flagB == 1) {

				if (startPos == currentPos) {
					return;
				}
				// Imageを非有効化して矢印を見えないように
				arrow.enabled = false;
				turn++;
				flagA = turn % 2;
				flagB = 2;
			}
		}
	}
}
