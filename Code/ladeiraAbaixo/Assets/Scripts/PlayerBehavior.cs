using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para controlar o comportamento do player
/// </summary>

public class PlayerBehavior : MonoBehaviour {

    //Referência para o corpo rígido do player
    private Rigidbody playerRB;

    [Tooltip ("Velocidade de movimento lateral do player")]
    [Range(1, 2000)]
    [SerializeField]
    public float horizontalPlayerSpeed = 5.0f;

    [Tooltip("Velocidade de movimento do player")]
    [Range(-2000,-1)]
    [SerializeField]
    public float playerSpeed = -5.0f;  

    // Use this for initialization
    void Start () {
        //Pegamos a referência do RB do player
        playerRB = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        //SE O JOGO ESTÁ PAUSADO, NÃO DEVE ATUALIZAR O PLAYER
        if (MainSceneBehavior._isPaused) {
            return;
            //TODO: IMPLEMENTAR A PAUSA DEFINITIVA PARANDO O TEMPO DO JOGO COM O TIMESCALE
        }

        /*Esse é a maneira de controlar o jogador pelo mouse. Deixamos de lado
        para usar via teclado
        //criamos a variável que vai ditar a direção do movimento
        float direction = 0.0f;
        //Pegamos a posição do mouse
        var position = Camera.main.ScreenToViewportPoint
            (Input.mousePosition);
        //Definimos a direção
        if(position.x < 0.5)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        var horizontalSpeed
            = direction * horizontalPlayerSpeed;
        //Aplicamos então a força
        playerRB.AddForce(horizontalSpeed, 0, (playerSpeed*-1));  
        */

        //-------------------------------
        //Controle do movimento do player:
        var horizontalSpeed = Input.GetAxis("Horizontal")
            * horizontalPlayerSpeed * Time.deltaTime;

        var verticalSpeed = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;

        //Como o jogo é invertido, vamos inverter a verticalSpeed
        playerRB.AddForce(horizontalSpeed, 0, (verticalSpeed * -1));
        //end controle do movimento do player
        //-------------------------------

        //Trecho que trata do clique sobre o boss, para mata-lo (Clique do botão esquerdo do mouse)
        if (Input.GetMouseButton(0))
        {
            TouchBoss(Input.mousePosition);
        }
    }

    //Método para identificar se objetos foram clicados (boss)
    static void TouchBoss(Vector3 clickPosition)
    { 
        //Convertemos a posição do clique para um ray
        Ray clickRay = Camera.main.ScreenPointToRay(clickPosition);

        //Salvaremos as informações de um possível objeto tocado
        RaycastHit hit;

        if (Physics.Raycast(clickRay, out hit))
        {
            hit.transform.SendMessage
                ("TouchedObject", SendMessageOptions.DontRequireReceiver);
        }
    }       
}

