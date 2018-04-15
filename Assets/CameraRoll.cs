using UnityEngine;
using System.Collections;

public class  CameraRoll : MonoBehaviour {
	
	void Start() {
		
	}
	
	void Update() {
//				this.transform.Ro tate(1, 1, 1);
//				Vector3 v = this.transform.position;
				if (Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(0,1,0);
				}   
				if (Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(0,-1,0);
				}
//				this.transform.position = v;
 
	}
}