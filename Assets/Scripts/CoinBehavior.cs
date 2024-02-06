using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinBehavior : MonoBehaviour
{
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
			GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(2);
            Destroy(this.gameObject);
        }
        
    }
}
