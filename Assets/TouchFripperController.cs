using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchFripperController : MonoBehaviour {

	private float width = Screen.width;

	// タッチした場合の座標
	public float startPos;

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;

	private float flickAngle = -20;


	void Start () {

		this.myHingeJoint = GetComponent<HingeJoint> ();

		SetAngle (this.defaultAngle);

	}

	void Update () {

		if (Input.touchCount > 0) {
			for(int i = 0; i < Input.touchCount; i++ ){
				//タッチしている指の数（0は1本目、1は2本目）
				// for文を使って本数を合わせる
				Touch touch = Input.GetTouch(i);
				// タッチしたx軸の位置
				startPos = touch.position.x;

				// タップすること（touch.phas）タップしたタイミングを設定（TouchPhase.BeganとTouchPhase.Stationary）
				if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary ) {
					if (startPos < width/2 && tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
					}else if (startPos > width/2 && tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
					}else if (startPos < width/2 &&startPos > width/2 &&tag == "LeftFripperTag"&&tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
					}
					// TouchPhase.Endedは画面から指が離れた時
				}else if(touch.phase == TouchPhase.Ended){
					SetAngle (this.defaultAngle);
				}
			}
		}
	}

	public void SetAngle(float angle){

		JointSpring jointspr = this.myHingeJoint.spring;
		jointspr.targetPosition = angle;
		this.myHingeJoint.spring = jointspr;
	}

}

