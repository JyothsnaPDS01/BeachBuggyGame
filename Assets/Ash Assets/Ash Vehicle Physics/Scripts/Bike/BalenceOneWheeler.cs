using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalenceOneWheeler : MonoBehaviour
{
	public Rigidbody Bike;
	public float LeanTorqueAmount;
	public AnimationCurve BalanceTorqueCurve;
	//public float leanAngle;
	public Vector3 NormalDirection;
	
	void FixedUpdate()
	{
		transform.position = Bike.transform.position;
	    
		//leanAngle = Vector3.AngleBetween(Bike.transform.up, Vector3.up);
	    
		
		NormalDirection = Vector3.Cross(Bike.transform.up, Vector3.up);
	    
		transform.forward = NormalDirection;
	    
		Vector3 LeanTorque = NormalDirection * LeanTorqueAmount;
		
		Bike.AddTorque(LeanTorque);
		
		//if(Bike.GetComponent<carController>().grounded)
		//{
		//	Bike.AddTorque(LeanTorque);
		//}
	
	}
	
}
