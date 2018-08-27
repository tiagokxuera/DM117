//Script para detectar o trigger do end game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameBehaviour : MonoBehaviour {

    private static string _VICTORYSCENE = "VictoryScene";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    //Vamos tratar a colisão tipo trigger para o fim do jogo - Apresentar a tela vitória    
    private void OnTriggerEnter(Collider other)
    {
        //Se foi uma colisão com o Player
        if (other.GetComponent<PlayerBehavior>())
        {
            //Mostrar a tela Vitória!
            SceneManager.LoadScene(_VICTORYSCENE);
        }
    }
}
