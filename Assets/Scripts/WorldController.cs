using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    public float dist;
    public float saved_dist;
    public int score;
    public Text dist_text;
    public Text score_text;
    public Text game_over_score;
    public Text game_over_dist;
    public Text high_score;
    public Text high_dist;
    public GameObject start_point;
    public GameObject player;
    public GameObject game_over_panel;
    public GameObject new_high_score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        score_text.text = ("score = "+score);
        if(GameObject.Find("Player")!=null)
        {
            dist = player.transform.position.x - start_point.transform.position.x;
        }
        saved_dist = dist;
        dist_text.text = ("distance = "+saved_dist);
        if(GameObject.Find("Player")==null)
        {
            game_over_panel.SetActive(true);
            game_over_score.text= ("SCORE = "+score);
            game_over_dist.text= ("DIST = "+saved_dist);
            if(score> PlayerPrefs.GetInt("highscore",0))
            {
                high_score.text = "HIGH SCORE = "+score.ToString();
                PlayerPrefs.SetInt("highscore", score);
                new_high_score.SetActive(true);
            }
            else
            {
                high_score.text = "HIGH SCORE = "+PlayerPrefs.GetInt("highscore");
            }
            if(saved_dist>PlayerPrefs.GetFloat("highdist",0f))
            {
                high_dist.text = "LONGEST DIST = "+saved_dist;
                PlayerPrefs.SetFloat("highdist", saved_dist);
                new_high_score.SetActive(true);
            }
            else
            {
                high_dist.text = "LONGEST DIST = "+PlayerPrefs.GetFloat("highdist");
            }
        }
    }
}
