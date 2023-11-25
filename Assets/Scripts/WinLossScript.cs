using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int winNum;
    public int currNum;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currNum = winNum;
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (player == null) {
            StartCoroutine(LoseLevel());

        }//if

        if (currNum == 0) {
            StartCoroutine(WinLevel());

        }//if
        
    }

    IEnumerator WinLevel() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("You win! Loading next level...");

        if (scene + 1 != 4) {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(scene + 1, LoadSceneMode.Single);

        }
        else {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(0);
        }

    }

    IEnumerator LoseLevel() {
        Debug.Log("You Died! Restarting level...");
        yield return new WaitForSeconds(5f);
        RestartLevel();

    }

    public void RestartLevel() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        Time.timeScale = 1;

    }

}
