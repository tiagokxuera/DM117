//Script de controle da GameOverScene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneBehavior : MonoBehaviour {

    private static string _INITIALSCENE = "InitialScene";
    //private static string _GAMEOVERBUTTON = "gameOverButton";

    //ATRIBUTO PRIVADO RESPONSÁVEL PELA MÚSICA DE FUNDO
    private AudioSource audioSource;

    //ATRIBUTO PÚBLICO RESPONSÁVEL PELOS EVENTOS OCORRIDOS NO BOTÃO <EXIBIÇÃO DE ADVERTISEMENT>
    //Botão não foi necessário
    //public Button GameOverButton;  

    //O ANÚNCIO COM RECOMPENSA SEMPRE SERÁ EXIBIDO QUANDO A TELA DE GAME OVER FOR INICIADA
    // Use this for initialization
    void Start() {

        //TO DO IF LOADINITIALSCENE WON'T WORK
        //Button restartButton = GameOverButton.GetComponent<Button>();
        //restartButton.onClick.AddListener(RestartButtonClicked);

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
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "REINICIAR". CARREGA A TELA INICIAL DO JOGO
    /// </summary>
    public void LoadInitialScene() {
        #if UNITY_ADS
            //SE O ANÚNCIO ESTIVER PRONTO PARA SER EXIBIDO, O EXIBE
            if (AdControlBehavior.showAds) {
                AdControlBehavior.ShowRewardAd();
            }
        #endif
        //INTERROMPE A EXECUÇÃO DA MÚSICA DE BACKGROUND DA INITIAL-SCENE
        audioSource.Stop();
        SceneManager.LoadScene(_INITIALSCENE);
    }

    //https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
    //TO DO IF LOADINITIALSCENE WON'T WORK
    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "REINICIAR". CARREGA ADVERTISEMENT DO JOGO
    /// </summary>
    //public void RestartButtonClicked() {
        //TO DO IF LOADINITIALSCENE WON'T WORK
    //}
}
