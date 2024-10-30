using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBeltMover : MonoBehaviour
{
	public Rigidbody vehicle;
	private Material beltMat;
	public float BeltSpeed;
	
	
	void Start()
	{
		beltMat = GetComponent<SkinnedMeshRenderer>().material;
	}
	
    void Update()
	{
		Vector2 TextureOffset = new Vector2 (0,-BeltSpeed* (vehicle.GetComponent<carController>().carVelocity.z)/1000 );
    	
		//beltMat.SetTextureOffset(beltMat.name,TextureOffset);
		beltMat.mainTextureOffset += TextureOffset;
    }
}
