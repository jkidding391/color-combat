using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;

public class TextScript : MonoBehaviour
{

    public string enemiesLeftCounter;
    public int enemiesLeft;
    [SerializeField] GameObject Tracker;
    [SerializeField] TMP_Text TextField;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = Tracker.GetComponent<WinLossScript>().currNum;
        enemiesLeftCounter = "Enemies Remaining To Win: " + enemiesLeft.ToString();
        TextField.SetText(enemiesLeftCounter);

    }

    // Update is called once per frame
    void Update()
    {
        enemiesLeft = Tracker.GetComponent<WinLossScript>().currNum;
        enemiesLeftCounter = "Enemies Remaining To Win: " + enemiesLeft.ToString();
        TextField.SetText(enemiesLeftCounter);
        
        
    }
}
