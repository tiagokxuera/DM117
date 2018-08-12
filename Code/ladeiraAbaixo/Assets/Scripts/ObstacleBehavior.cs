using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehavior : MonoBehaviour {
    [Tooltip("Tempo antes de reiniciar o jogo")]
    public float timeToEnd = 2.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Verificamos se é o player primeiro
        if (collision.gameObject.GetComponent<PlayerBehavior>())
        {
            Destroy(collision.gameObject);
            Invoke("GameReset", timeToEnd);
        }
    }

    //Reinicia o jogo
    void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

