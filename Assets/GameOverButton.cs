using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RETRY()
    {
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }
    public void QUIT()
    {
        Application.Quit();
    }
}
