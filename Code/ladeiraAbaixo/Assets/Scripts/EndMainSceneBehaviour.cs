using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMainSceneBehaviour : MonoBehaviour {

    private static string _MAINSCENE2 = "MainScene2";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Vamos tratar a colisão tipo trigger para o
    //Gatilhar a fase 2
    private void OnTriggerEnter(Collider other)
    {
        //Se foi uma colisão com o Player
        if (other.GetComponent<PlayerBehavior>())
        {
            //INTERROMPE A EXECUÇÃO DA MÚSICA DE BACKGROUND            
            SceneManager.LoadScene(_MAINSCENE2);
        }
    }
}
