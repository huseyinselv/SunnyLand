using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
   


    public void OyunaBasla()
    {
        SceneManager.LoadScene("sahne1");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }
}
