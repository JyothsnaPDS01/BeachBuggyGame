using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carChanger : MonoBehaviour
{
	public GameObject[] cars;
	
	[SerializeField]private int carNum = 0;
	
	private GameObject car;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		car = Instantiate(cars[carNum],transform.position,Quaternion.identity);
		car.transform.parent = this.transform;
	}
	
	public void changeCarNumber()
	{
		if(carNum == cars.Length -1){
			carNum = 0;
		}else{
			carNum += 1;
		}
		
		car = Instantiate(cars[carNum],transform.position,Quaternion.identity);
		car.transform.parent = this.transform;
		Destroy(transform.GetChild(0).gameObject);
	}
	
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void Quit(){
		Application.Quit();
	}
}
