using UnityEngine;
using System.Collections;

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
}
