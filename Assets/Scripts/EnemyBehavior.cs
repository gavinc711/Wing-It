using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject enemyBulletPrefab;
    public GameObject explosionPrefab;
	public GameObject gM;
	public int hitcount;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");
		
		if (this.tag == "Boss")
			InvokeRepeating("Shooting", 0.5f, 1.0f);
		else
			InvokeRepeating("Shooting", 0.5f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
			if (whatIHit.GetComponent<PlayerBehavior>().shield.activeInHierarchy == true)
			{
				gM.GetComponent<GameManager>().IncreaseEnemyCount();
				Instantiate(explosionPrefab, transform.position, Quaternion.identity);
				whatIHit.GetComponent<PlayerBehavior>().shield.SetActive(false);
				Destroy(this.gameObject);
			}
			else 
			{
				gM.GetComponent<GameManager>().IncreaseEnemyCount();
				whatIHit.GetComponent<PlayerBehavior>().LoseLife();
				Instantiate(explosionPrefab, transform.position, Quaternion.identity);
				Destroy(this.gameObject);
			}
        }
        else if (whatIHit.tag == "Weapon")
        {
			if (this.tag == "Boss")
			{
				hitcount += 1;
				Destroy(whatIHit.gameObject);
				
				if (hitcount == 50)
				{
					gM.GetComponent<GameManager>().round += 1;
					gM.GetComponent<GameManager>().EarnScore(100);
					gM.GetComponent<GameManager>().RoundStart();
					Instantiate(explosionPrefab, transform.position, Quaternion.identity);
					Destroy(this.gameObject);
				}
			}
			else 
			{
				gM.GetComponent<GameManager>().EarnScore(2);
				gM.GetComponent<GameManager>().IncreaseEnemyCount();
				Instantiate(explosionPrefab, transform.position, Quaternion.identity);
				Destroy(whatIHit.gameObject);
				Destroy(this.gameObject);
			}
        }
    }
	
	void Shooting()
    {
		if(this.tag == "Boss")
		{
			Instantiate(enemyBulletPrefab, transform.position + new Vector3(0.5f, -1, 0), Quaternion.Euler(0, 0, 45f));
			Instantiate(enemyBulletPrefab, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
			Instantiate(enemyBulletPrefab, transform.position + new Vector3(-0.5f, -1, 0), Quaternion.Euler(0, 0, -45f));
		}
		else 
		{
			Instantiate(enemyBulletPrefab, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
		}
	}
}
