using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Initializer : MonoBehaviour 
{

	public Transform Pickup;
	public int PickupCount;

	// Use this for initialization
	void Start () 
	{
		if (PickupCount <= 0)
			PickupCount = 12;
		
		var r = 5.0;
		var delta_theta = 2 * Mathf.PI / PickupCount;
		for (var i = 0; i < PickupCount; ++i) {
			float x = (float) r * Mathf.Cos (i * delta_theta);
			float y = Pickup.position.y;
			float z = (float) r * Mathf.Sin(i * delta_theta);
			Instantiate(Pickup, new Vector3 (x, y, z), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void Export()
	{
		string output_path = "output";
		if (!Directory.Exists (output_path))
			Directory.CreateDirectory (output_path);

		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
		int i = 0;
		foreach (GameObject go in allObjects) {
			if (go.activeInHierarchy) {
				if (go.CompareTag("Export")) {
					Export (output_path, i, go);
					++i;
				}
			}
		}
	}

	public void Export(string outputPath, int i, GameObject go)
	{
		string output_file = Path.Combine (outputPath, i.ToString () + ".txt");

		MeshFilter mf = go.GetComponent<MeshFilter> ();
		Vector3[] veticies = mf.mesh.vertices;
		int[] triangles = mf.mesh.triangles;
		List<Vector3> vert_list = new List<Vector3>();

		foreach (int idx in triangles)
			vert_list.Add (veticies[idx]);

		List<string> str_list = new List<string> ();
		foreach (Vector3 v in vert_list) {
			str_list.Add(v.x + " " + v.y + " " + v.z);
		}

		File.WriteAllLines (output_file, str_list.ToArray());
	}
}
