using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger : MonoBehaviour
{


    public void ResetScene(){
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadTitle(){
        SceneManager.LoadScene("TitleScreen");

    }

}
