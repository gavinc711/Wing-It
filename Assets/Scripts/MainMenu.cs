using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public TextMeshProUGUI startText;
	public TextMeshProUGUI creditsText;
	public TextMeshProUGUI creditsNotifText;
	
    // Start is called before the first frame update
    void Start()
    {
        creditsText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
		
		if(Input.GetKeyDown(KeyCode.C))
		{
			if (creditsText.enabled == false)
			{
				startText.enabled = false;
				creditsText.enabled = true;
				creditsNotifText.text = "Press C to go back";
				
			}
			else if (creditsText.enabled == true)
			{
				startText.enabled = true;
				creditsText.enabled = false;
				creditsNotifText.text = "Press C for credits";
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
