using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int winNum;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (player == null) {
            StartCoroutine(LoseLevel());

        }//if

        if (winNum == 0) {
            StartCoroutine(WinLevel());

        }//if
        
    }

    IEnumerator WinLevel() {
        Debug.Log("You win! Restarting level...");
        yield return new WaitForSeconds(5f);
        RestartLevel();

    }

    IEnumerator LoseLevel() {
        Debug.Log("You Died! Restarting level...");
        yield return new WaitForSeconds(5f);
        RestartLevel();

    }

    public void RestartLevel() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;

    }

}
