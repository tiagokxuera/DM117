using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para controlar o comportamento da câmera
/// </summary>

public class CameraBehavior : MonoBehaviour {

    [Tooltip("Alvo que a câmera seguirá")]
    [SerializeField]
    public Transform target;

    [Tooltip("Offset da camera em relação ao alvo")]
    [SerializeField]
    public Vector3 offSet = new Vector3(0, 3, -6);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Testamos para evitar que entre com um target null
		if(target != null)
        {
            //Altera a posição da câmera
            transform.position = target.position + offSet;

            //Faz a câmera olhar para o player
            transform.LookAt(target);
        }
	}
}
