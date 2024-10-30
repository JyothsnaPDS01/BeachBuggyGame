
using UnityEngine;

[ExecuteAlways]
public class VehicleEditor : MonoBehaviour
{
	[Header("Vehicle Stats")]

    [Range(0, 10)]
    public float wheelRadious = 0.34f;
    [Range(-10,0)]
    public float wheelYPosition = -0.5f ;
    [Range(0, 10)]
    public float FrontWheelsZPosition = 1.5f;
    [Range(-10, 0)]
    public float RearWheelsZPosition = -1.5f;
    [Range(0, 10)]
	public float GapBetweenWheels = 1f;
	public float SuspentionForce = 10000f;
	public float Damper = 100f;
	public float DeltaRayLength = 0.1f;
	private Transform GroundRayPt;
	
    void Update()
	{
		

		Transform wheels = transform.GetComponent<References>().wheels;

		Transform wheelFL = transform.GetComponent<References>().wheelFL;
	    Transform wheelFR = transform.GetComponent<References>().wheelFR;
	    Transform wheelRL = transform.GetComponent<References>().wheelRL;
	    Transform wheelRR = transform.GetComponent<References>().wheelRR;


		//setting position of wheels
		wheels.localPosition = new Vector3(0, wheelYPosition, 0);
	    wheelFL.localPosition = new Vector3(-GapBetweenWheels, 0, FrontWheelsZPosition);
        wheelFR.localPosition = new Vector3(GapBetweenWheels, 0, FrontWheelsZPosition);
        wheelRL.localPosition = new Vector3(-GapBetweenWheels, 0, RearWheelsZPosition);
        wheelRR.localPosition = new Vector3(GapBetweenWheels, 0, RearWheelsZPosition);

        //wheel radious adjust
        wheelFL.GetComponent<SphereCollider>().radius = wheelRadious;
        wheelFR.GetComponent<SphereCollider>().radius = wheelRadious;
        wheelRL.GetComponent<SphereCollider>().radius = wheelRadious;
	    wheelRR.GetComponent<SphereCollider>().radius = wheelRadious;
	    
	    var ydrive =   wheelFL.GetComponent<ConfigurableJoint>().yDrive;
	    ydrive.positionDamper = Damper;
	    ydrive.positionSpring = SuspentionForce;
	    
	    
	    wheelFL.GetComponent<ConfigurableJoint>().yDrive = ydrive;
	    wheelFR.GetComponent<ConfigurableJoint>().yDrive = ydrive;
	    wheelRL.GetComponent<ConfigurableJoint>().yDrive = ydrive;
		wheelRR.GetComponent<ConfigurableJoint>().yDrive = ydrive;
	    
		if(transform.GetComponent<References>().GroundRayPt == null)
		{
			transform.GetComponent<carController>().maxRayLength = -wheelYPosition + (DeltaRayLength + wheelRadious);
			return;
		}
		else
		{
			GroundRayPt = transform.GetComponent<References>().GroundRayPt;
		}
    	
		transform.GetComponent<carController>().maxRayLength = GroundRayPt.localPosition.y-wheelYPosition + (DeltaRayLength + wheelRadious);
	    
    }
}

