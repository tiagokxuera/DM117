using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxBossBehaviour : MonoBehaviour {

    private static string _GAMEOVERSCENE = "GameOverScene";

    //Não deixa entrar na rotina de tempo
    private bool flagTimer = false;

    [Tooltip("Alvo que o Boss Seguirá")]
    [SerializeField]
    public Transform target;
  
    [Tooltip("Alvo está em perseguição")]
    [SerializeField]
    public bool bossRunning = false;

    [Tooltip("Efeito de destruição do Boss")]
    [SerializeField]
    public GameObject explosion;

    //Transform usado para calcular o deslocamento do boss em direção ao player (transform)
    public Transform startMarker;
    //Transform usado para calcular o deslocamento do bosss em direção ao player (target)
    public Transform endMarker;
    
    // Movement speed in units/sec.
    [Tooltip("Velocidade do Boss na perseguição")]
    [SerializeField]
    public float speed = 0.8f;
    // Time when the movement started.
    private float startTime;
    // Total distance between the markers.
    private float journeyLength;

    //Referência para o áudio
    private AudioSource source;

    [Tooltip("Tempo antes de reiniciar o jogo")]
    public float timeToEnd = 2.0f;

    // Use this for initialization
    void Start () {
        ObstacleBehavior._isGameOver = false;
        source = GetComponent<AudioSource>();       
    }
    
    // Update is called once per frame
    void Update () {
        if (bossRunning) {
            //vamos correr atrás do jogador
            //Testamos para evitar que entre com um target null
            if (target != null) {
                //Se já é hora de chamar o deslocamento do boss
                if (!flagTimer) {
                    flagTimer = true;
                    //Executa a rotina abaixo a cada 0.1s
                    StartCoroutine(BossOffSet(0.1f));
                }                
            }
        }
    }

    //Função que roda em paralelo. Cai aqui a cada "time", para recalcular a posição do boss
    IEnumerator BossOffSet(float time) { 
        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    
        //Gera o tempo
        yield return new WaitForSeconds(time);
        //Flag para permitir novo gatilho de tempo.
        flagTimer = false;
    }

    //Esse método será chamado pelo objeto que starta o trigger do player
    //Ele vai disparar a perseguição
    public void SetRunninON() {
        //Coloco o local de origem e destino da perseguição
        startMarker = transform;
        endMarker = target;

        //Sinalizo que começou a perseguição
        bossRunning = true;

        // Keep a note of the time the movement started.
        startTime = Time.time;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    //Esse método será chamado pelo objeto que starta o trigger do player
    //Ele vai encerrar a perseguição
    public void SetRunninOFF() {
        bossRunning = false;
    }

    //Método que será chamado via send message, 
    //para detectar que esse objeto foi tocado
    public void TouchedObject() {
        KillBoss();
    }

    private void OnCollisionEnter(Collision collision) {
        //Verificamos se é um obstáculo para matar o boss
        if (collision.gameObject.GetComponent<ObstacleBehavior>()) {
            KillBoss();
        }

        //Verificamos se é o player primeiro
        if (collision.gameObject.GetComponent<PlayerBehavior>()) {
            ObstacleBehavior._isGameOver = true;
            Destroy(collision.gameObject);
            Invoke("GameOver", timeToEnd);      
        }      
    }

    /// <summary>
    /// MÉTODO DISPARADO PELA COLISÃO DO PLAYER COM O BOSS. CARREGA A TELA-GAMEOVER DO JOGO
    /// </summary>
    public void GameOver() {
        SceneManager.LoadScene(_GAMEOVERSCENE);
    }

    public void KillBoss() {
        if (explosion != null) {
            var exploded = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exploded, 2.0f);
        }
        AudioSource.PlayClipAtPoint(source.clip, transform.position);
        Destroy(this.gameObject);
    }
}