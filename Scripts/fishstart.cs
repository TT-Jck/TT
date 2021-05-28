using UnityEngine;
using System.Collections;

	public class fishstart : MonoBehaviour {
	public GameObject fish;


	public int fishnum=3;


//	public countfox rabbitCounter;
	// Use this for initialization
	void Start () {
	
		//foxCounter.count_rabbit = 1;

		for ( int i=0;i<=fishnum;i++)
		{

			Instantiate (fish, new Vector3 (510f, 15f,520f), Quaternion.identity);
			                        
		}

	}
}
