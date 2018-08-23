using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneBehavior : MonoBehaviour {

    private static string _INITIALSCENE = "InitialScene";
    private static string _PAUSESCENE = "PauseScene";

    public static bool _isPaused;

    //ATRIBUTO PRIVADO RESPONSÁVEL PELA MÚSICA DE FUNDO
    private AudioSource audioSource;

    [Tooltip("Referência para o GO PauseMenuPanel. Usado para Ligá-lo/Desligá-lo")]
    public GameObject pauseMenu;


	// Use this for initialization
	void Start () {
        _isPaused = false; 

        //SE PLATAFORMA QUE ESTIVER EXECUTANDO O JOGO NÃO CONTEMPLAR ANÚNCIOS, O CÓDIGO ABAIXO SERÁ EXECUTADO NORMALMENTE
        #if !UNITY_ADS
            PauseOrResume(false);
        #endif

        //INICIA A EXECUÇÃO DA MÚSICA DE BACKGROUND DA INITIAL-SCENE [Fonte: https://docs.unity3d.com/ScriptReference/AudioSource.Stop.html]
        audioSource.Play();
    }

    // Use this for initialization
    void Update() {
        //SE JOGO ESTÁ PAUSADO OU OCORREU COLISÃO DO PLAYER COM ALGUM OBSTÁCULO
        if (MainSceneBehavior._isPaused) {
            audioSource.Pause();
            Time.timeScale = 0f;
            return;
        } else if(ObstacleBehavior._isGameOver) {
            audioSource.Pause();
        } else {
            audioSource.UnPause();
            Time.timeScale = 1f;
        } 
    }

    //O MÉTODO AWAKE SOMENTE É EXECUTADO UMA VEZ ANTES DO MÉTODO START() SER EXECUTADO
    private void Awake() {
        //BUSCA PELO COMPONENTE AUDIO-SOURCE DO GO
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "PAUSE". CARREGA A TELA DE PAUSE
    /// </summary>
    public void LoadPauseScene() {
        SceneManager.LoadScene(_PAUSESCENE);
    }

    /// <summary>
    /// MÉTODO PARA PAUSAR/RESUMIR O JOGO
    /// </summary>
    /// <param name="isPaused">VARIÁVEL TO TIPO BOOL QUE QUANDO SETADA PARA TRUE INDICA QUE O JOGO SERÁ PAUSADO</param>
    public void PauseOrResume(bool isPaused) {
        //isPaused = true .:. JOGO SERÁ PAUSADO
        //isPaused = false .:. JOGO SERÁ DESPAUSADO
        _isPaused = isPaused;
    }

    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "REINICIAR". CARREGA A FASE-CORRENTE DO JOGO
    /// </summary>
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _isPaused = false;
    }

    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "ABANDONAR". CARREGA A TELA-INICIAL DO JOGO
    /// </summary>
    public void Quit() {
        SceneManager.LoadScene(_INITIALSCENE);
        audioSource.Stop();
    }

}
