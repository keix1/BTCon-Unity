using UnityEngine;
using System.Collections;

public class myscript   : MonoBehaviour {
	float multi = 0.0f;

	void Start() {

	}

	void Update() {
		if(Input.GetKey ("1")) {
			multi += 0.01f;
			double pipi= Mathf.PI*multi/2.0f;
			var x = 5 * Mathf.Sin((float)pipi);
			var z = 5 * Mathf.Cos((float)pipi);
			transform.position = new Vector3(x, 0.5f, z);
		}
		if(Input.GetKey ("2")) {
			multi -= 0.01f ;
			double pipi= Mathf.PI*multi/2.0f ;
			var x = 5 * Mathf.Sin((float)pipi);
			var z = 5 * Mathf.Cos((float)pipi);
			transform.position = new Vector3(x, 0.5f, z);
		}
	}
}




	//	public GameObject ball;
//	
//	// Use this for initialization
//	void Start () {
//		for (int i=0 ; i<3 ; ++i) {
//			Instantiate(ball,new Vector3(Random.Range(-0.5f,0.5f)*10,i*10+10,Random.Range(-0.5f,0.5f)*10),Quaternion.identity);
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (Input.GetKey(KeyCode.LeftArrow)){
//			 // create ball random position
// 			Instantiate(ball,new Vector3(Random.Range(-0.5f,0.5f)*10,1*10+10,Random.Range(-0.5f,0.5f)*10),Quaternion.identity); 
//		}
//		
//	}
//}
//
//



//using UnityEngine;
//using System.Collections;
//
//public class myscript : MonoBehaviour {
//	private float num;
//
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		this.transform.Rotate(1, 1, 1);
//		Vector3 v = this.transform.position;
//		if (Input.GetKey(KeyCode.LeftArrow)){
//			v.x -= 0.05f;
//		}
//		if (Input.GetKey(KeyCode.RightArrow)){
//			v.x += 0.05f;
//		}
//		if (Input.GetKey(KeyCode.UpArrow)){
//			v.z += 0.05f;
//		}
//		if (Input.GetKey(KeyCode.DownArrow)){
//			v.z -= 0.05f;
//		}
//		this.transform.position = v;
//	}

//	// Use this for initialization
//	void Start () {
//		num = 1.0f;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		Quaternion q = Quaternion.Euler(num,  0.0f, 0.0f);
//		transform.rotation = q;
//		num++;
//	}





	// Use this for initialization
//	void Start () {
//		num = 3.0f;
//	}
//	
//	// Update is called once per frame
//	void Update () {
////		this.transform.Rotate(num, num, num); 
////		this.transform.Translate(0.1f, 0.0f, 0.0f);
//		Vector3 v = this.transform.position;
//		v.x += 0.5f;
//		this.transform.position = v; 
//	}
//}