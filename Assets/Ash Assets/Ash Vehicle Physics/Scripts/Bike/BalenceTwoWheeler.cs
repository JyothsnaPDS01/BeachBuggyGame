using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalenceTwoWheeler : MonoBehaviour
{
	public Rigidbody Bike;
	public float LeanTorqueAmount;
	public AnimationCurve BalanceTorqueCurve;
	public bool AlwaysAddTorque;
	
	void FixedUpdate()
	{
		transform.forward = Bike.transform.forward;
		transform.position = Bike.transform.position;
	    
		Vector3 LeanTorque = new Vector3(0,0,100*LeanTorqueAmount 
			* Vector3.Dot(transform.right, Bike.transform.up)
		    *BalanceTorqueCurve.Evaluate(Mathf.Abs(Bike.GetComponent<carController>().carVelocity.z)));
		
		if(AlwaysAddTorque)
		{
			Bike.AddRelativeTorque(LeanTorque);
		}
		else if(Bike.GetComponent<carController>().grounded)
		{
			Bike.AddRelativeTorque(LeanTorque);
		}
		
	}
	
}
