using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private Vector3 force;

	private void setCount()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
			winText.text = "Game Complete!";
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCount ();
		winText.text = "";
		force = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		force = movement * speed;
		rb.AddForce (force);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			++count;
			setCount ();
		}
	}

	public void Reset()
	{
		transform.position = new Vector3(0, 0.5f, 0);
		rb.velocity = Vector3.zero;
		rb.AddForce (-force);
		force = Vector3.zero;
	}

	/*
	public void Export()
	{
		List<Vector3> vert_list = new List<Vector3>();

		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
		foreach (GameObject go in allObjects) {
			if (go.activeInHierarchy) {
				if (go.CompareTag("Export")) {
					MeshFilter mf = go.GetComponent<MeshFilter> ();
					Vector3[] veticies = mf.mesh.vertices;
					int[] triangles = mf.mesh.triangles;

					foreach (int idx in triangles)
						vert_list.Add (veticies[idx]);

					//print (go.name +": position = " + go.transform.position);
					//print (go.name +": rotation = " + go.transform.rotation);
					//print (go.name +": localScale = " + go.transform.localScale);
					//print ("verticies:");

					//int i = 0;
					//foreach (Vector3 v in veticies) {
					//	print (++i + ": " + v);
					//}

				}
			}
		}

		List<string> str_list = new List<string> ();
		foreach (Vector3 v in vert_list) {
			str_list.Add(v.x + " " + v.y + " " + v.z);
		}

		//string str = string.Join (";", str_list.ToArray());
		//print (str);

		File.WriteAllLines ("verticies.txt", str_list.ToArray());
	}
	*/
}
