
using UnityEngine;

public class References : MonoBehaviour
{
	public Transform GroundRayPt;


	public Transform wheels;

	public Transform wheelFL;
	public Transform wheelFR;
	public Transform wheelRL;
	public Transform wheelRR;


	private void OnEnable()
	{
		transform.GetComponent<VehicleEditor>().enabled = false;
	}
	private void OnDisable()
	{
		transform.GetComponent<VehicleEditor>().enabled = true;
	}
}
