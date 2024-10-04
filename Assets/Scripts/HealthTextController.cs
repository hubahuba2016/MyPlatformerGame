using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthTextController : MonoBehaviour
{
    public Text this_text;
    public PlayerController player_script;
    // Start is called before the first frame update
    void Start()
    {
        this_text= this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this_text.text="health = "+player_script.health;
    }
}
