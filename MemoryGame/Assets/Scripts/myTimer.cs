using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myTimer : MonoBehaviour {

   
    public float vrijeme = 15;
    public Text timerText;

	// Use this for initialization
	void Start () {

        timerText = GetComponent<Text>() as Text;
	
	}
	
	// Update is called once per frame
	void Update () {
        vrijeme -= Time.deltaTime;

        if (vrijeme < 10)
        {
            Debug.Log("TEN SECONDS LEFT !");
            
        }
        //   timerText.text = vrijeme.ToString("00");



    }
}
