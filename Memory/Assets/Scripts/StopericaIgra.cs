using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopericaIgra : MonoBehaviour
{

    public float vrijeme;
    public Text timerText;
    public bool isteklo = false;
    public int brojac = 0;

    // Use this for initialization
    void Start()
    {

       Scene level = SceneManager.GetActiveScene();
        if (level.name == "EasyLevel") vrijeme = 60;
        else if (level.name == "MediumLevel") vrijeme = 40;
        else if (level.name == "HighLevel") vrijeme = 5;
        timerText = GetComponent<Text>() as Text;

    }

    // Update is called once per frame
    void Update()
    {
        if (isteklo == false && vrijeme>0)
        {
            vrijeme -= Time.deltaTime;

            timerText.text = ("Vrijeme: " + vrijeme.ToString("f0"));
            print(vrijeme);
        }
        else
        {
            isteklo = true;
            brojac++;
            timerText.text = "Vrijeme isteklo!";
            StartCoroutine(sacekaj());
            
        }
        /*    if (vrijeme <= 0)

                timerText.text = "Vrijeme isteklo!";
                SceneManager.LoadScene(level.name);
        }*/

    }
    IEnumerator sacekaj()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Level");
        }
    }
}
