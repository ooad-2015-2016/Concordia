using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour, Assets.Scripts.ILevel
{


    // Use this for initialization
    public void odaberiOpciju()
    {

        SceneManager.LoadScene("Level");

    }


}
