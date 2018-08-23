using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSnowManBehaviour : MonoBehaviour {

    //Referência para o Script FoxBossBehaviour
    public SnowManBossBehaviour snowManBossBehaviour;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Vamos tratar a colisão tipo trigger para o
    //Boss começar a correr atrás do player
    private void OnTriggerEnter(Collider other)
    {
        //Se foi uma colisão com o Player
        if (other.GetComponent<PlayerBehavior>())
        {
            snowManBossBehaviour = GameObject.FindObjectOfType(typeof(SnowManBossBehaviour)) as SnowManBossBehaviour;
            snowManBossBehaviour.SetRunninOFF();
        }
    }
}
