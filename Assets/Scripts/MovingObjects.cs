using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public int objectType;
	Vector3 pointA;
	Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
		pointA = new Vector3(-8, 6, 0);
		pointB = new Vector3(8, 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(objectType == 1) 
        {
            //You are a bullet
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
        } else if (objectType == 2)
        {
            //You are an enemy bullet
			transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 8f);
        } else if (objectType == 3)
        {
            //You are enemy one
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 2f);
        } else if (objectType == 4)
        {
            //You are enemy two
            transform.Translate(new Vector3(-0.5f, -1, 0) * Time.deltaTime * 2f);
        } else if (objectType == 5)
        {
            //You are enemy three
            transform.Translate(new Vector3(0.5f, -1, 0) * Time.deltaTime * 2f);
        } else if (objectType == 6)
        {
			//You are the boss
			float time = Mathf.PingPong(Time.time * 0.3f, 1);
			transform.position = Vector3.Lerp(pointA, pointB, time);
        }

        if(transform.position.y > 11f || transform.position.y < -11f) 
        {
            Destroy(this.gameObject);
        }
    }
}