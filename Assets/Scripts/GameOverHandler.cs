using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour {

    public Text GameOverText;

	IEnumerator Start()
    {
        GameOverText.text = "Game Over!";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
