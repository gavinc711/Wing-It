using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		if (this.tag == "Item")
			Destroy(this.gameObject, 5f);
		else
			Destroy(this.gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}