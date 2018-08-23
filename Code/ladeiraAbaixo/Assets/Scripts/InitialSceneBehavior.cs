using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneBehavior : MonoBehaviour {

    private static string _MAINSCENE = "MainScene";
    private static string _PAUSECENE = "PauseScene";
    private static string _GAMEOVERSCENE = "GameOverScene";

    //ATRIBUTO PRIVADO RESPONSÁVEL PELA MÚSICA DE FUNDO
    private AudioSource audioSource;


    // Use this for initialization
    void Start() {
        //INICIA A EXECUÇÃO DA MÚSICA DE BACKGROUND DA INITIAL-SCENE [Fonte: https://docs.unity3d.com/ScriptReference/AudioSource.Stop.html]
        audioSource.Play();
    }

    // Update is called once per frame
    void Update() {

    }

    //O MÉTODO AWAKE SOMENTE É EXECUTADO UMA VEZ ANTES DO MÉTODO START() SER EXECUTADO
    private void Awake() {
        //BUSCA PELO COMPONENTE AUDIO-SOURCE DO GO
        audioSource = GetComponent<AudioSource>();
    }


    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "JOGAR". CARREGA A PRIMEIRA-FASE DO JOGO
    /// </summary>
    public void LoadMainScene() {
        //INTERROMPE A EXECUÇÃO DA MÚSICA DE BACKGROUND DA INITIAL-SCENE
        audioSource.Stop();
        SceneManager.LoadScene(_MAINSCENE);
    }

    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "JOGAR". CARREGA A TELA DE PAUSA DO JOGO
    /// </summary>
    public void LoadPauseScene() {
        SceneManager.LoadScene(_PAUSECENE);
    }

    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "JOGAR". CARREGA A TELA DE GAMEOVER DO JOGO <PARA TESTE DOS ADS>
    /// </summary>
    public void LoadGameOverScene() {
        SceneManager.LoadScene(_GAMEOVERSCENE);
    }
}
