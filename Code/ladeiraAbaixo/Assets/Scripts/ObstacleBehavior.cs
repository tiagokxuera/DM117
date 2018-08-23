using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehavior : MonoBehaviour {

    public static bool _isGameOver;

    private static string _GAMEOVERSCENE = "GameOverScene";

    [Tooltip("Tempo antes de reiniciar o jogo")]
    public float timeToEnd = 2.0f;

    // Use this for initialization
    void Start () {
        _isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Verificamos se é o player primeiro
        if (collision.gameObject.GetComponent<PlayerBehavior>()) {
            _isGameOver = true;
            Destroy(collision.gameObject);
            Invoke("GameOver", timeToEnd);
        }
    }

    /// <summary>
    /// MÉTODO DISPARADO PELA COLISÃO DO PLAYER COM ALGUM OBSTÁCULO. CARREGA A TELA-GAMEOVER DO JOGO
    /// </summary>
    public void GameOver() {
        SceneManager.LoadScene(_GAMEOVERSCENE);
    }

}

