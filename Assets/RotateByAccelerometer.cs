using UnityEngine;
using VR = UnityEngine.VR;
using System.Collections;
using System.Collections.Generic;

public class RotateByAccelerometer : MonoBehaviour
{
	public SerialHandler serialHandler;
	public GameObject cube;
	private bool deathFlag = false;
	
	private List<Vector3> angleCache = new List<Vector3>();
	public int angleCacheNum = 10;
	public ScoreText scoreText;
	private GameObject gameCube;
	private Transform cameraOculus; 
	Quaternion direcOculus;
	void Start()
	{
		serialHandler.OnDataReceived += OnDataReceived;
		//cameraOculus = transform.FindChild ("MainCamera"); 
	}
	
	void Update()
	{
	
		if (Input.GetKey(KeyCode.LeftArrow)){
			// create ball random position
		//	Instantiate(cube,new Vector3(Random.Range(-0.5f,0.5f)*10,1*10+10,Random.Range(-0.5f,0.5f)*10),Quaternion.identity); 
		}

		if (Input.GetKey("7")){
			//Application.Quit();
 			gameCube = (GameObject)GameObject.Instantiate (cube,new Vector3(direcOculus.x*3.0f,2.0f,direcOculus.z*3.0f ),Quaternion.identity);
		}
	}
	
	void OnDataReceived(string message)
	{
		double pipi= Mathf.PI*float.Parse(message)/180.0f; 
//		Vector3 Cameraforward = Camera.main.transform.TransformDirection(Vector3.forward); 
		direcOculus = UnityEngine.XR.InputTracking.GetLocalRotation (UnityEngine.XR.XRNode.CenterEye);
		var x = 5 * Mathf.Sin((float)pipi+Mathf.PI*direcOculus.eulerAngles.y/180.0f);
		var z = 5 * Mathf.Cos((float)pipi+Mathf.PI*direcOculus.eulerAngles.y/180.0f);
		Debug.Log ("pipi=" + pipi);
		Debug.Log ("x=" + x);
		Debug.Log ("z=" + z);
		Debug.Log ("direcOculus.eulerAngles.y=" + Mathf.PI*direcOculus.eulerAngles.y/180.0f);

		//var x = Cameraforward.x;
		//var z = Cameraforward.z;

		
		if (deathFlag && gameCube != null) { 
			GameObject.Destroy(gameCube);
		}
		deathFlag = true;

		//gameCube = (GameObject)GameObject.Instantiate (cube,new Vector3(x,0.0f,z),Quaternion.identity);//,new Vector3(1.0f,1.0f,1.0f)); //Random.Range(-0.5f,0.5f)*10,1*10+10,Random.Range(-0.5f,0.5f)*10),Quaternion.identity);
		gameCube = (GameObject)GameObject.Instantiate (cube,new Vector3(x,0.0f,z),Quaternion.identity);//,new Vector3(1.0f,1.0f,1.0f)); //Random.Range(-0.5f,0.5f)*10,1*10+10,Random.Range(-0.5f,0.5f)*10),Quaternion.identity);

		scoreText.GetComponent<ScoreText> ().st = message;

//		var data = message.Split(
//			new string[]{"\t"}, System.StringSplitOptions.None);
//		if (data.Length < 2) return;
//		 
//		try {
//			var angleX = float.Parse(data[0]);
//			var angleY = float.Parse(data[1]);
//			angle = new Vector3(angleX, 0, angleY);
//		} catch (System.Exception e) {
//			Debug.LogWarning(e.Message);
//		}
	}
}