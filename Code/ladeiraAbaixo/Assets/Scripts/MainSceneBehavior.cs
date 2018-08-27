//Comportamento da MainScene e MainScene2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneBehavior : MonoBehaviour {

    //Referência para InitialScene
    private static string _INITIALSCENE = "InitialScene";
    //Referência para a PauseScene
    private static string _PAUSESCENE = "PauseScene";

    //Criamos aqui 3 GO que serão destruídos como recompensa do AD
    private GameObject arvore1;
    private GameObject arvore2;
    private GameObject arvore3;

    //Variável que indica se o game esta pausado ou não.
    public static bool _isPaused;
    
    //flag usado para saber se o user assistiu ao advertisement (e depois damos a recompensa)
    public static bool _adDone=false;

    //ATRIBUTO PRIVADO RESPONSÁVEL PELA MÚSICA DE FUNDO
    private AudioSource audioSource;

    [Tooltip("Referência para o GO PauseMenuPanel. Usado para Ligá-lo/Desligá-lo")]
    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
        _isPaused = false;

        //Buscamos as três árvores pelas TAGS que foram atribuídas lá no Unity (fica instanciado para destruí-las
        arvore1 = GameObject.FindGameObjectWithTag("Destroyable1");
        arvore2 = GameObject.FindGameObjectWithTag("Destroyable2");
        arvore3 = GameObject.FindGameObjectWithTag("Destroyable3");

        //SE PLATAFORMA QUE ESTIVER EXECUTANDO O JOGO NÃO CONTEMPLAR ANÚNCIOS, O CÓDIGO ABAIXO SERÁ EXECUTADO NORMALMENTE
#if !UNITY_ADS
            PauseOrResume(false);
#endif

        //INICIA A EXECUÇÃO DA MÚSICA DE BACKGROUND DA INITIAL-SCENE [Fonte: https://docs.unity3d.com/ScriptReference/AudioSource.Stop.html]
        audioSource.Play();
    }

    // Use this for initialization
    void Update() {
        //Se _adDone = true, significa que o jogador assistiu ao Advertisement, então destruimos para ele, três GO (árvores) no início da fase como recompensa
        if (_adDone==true)
        {
            //Debug para saber se o advertisement
            Debug.Log("MainScene-Entrou após o advertisement");

            //Colocar aqui os eventos que a recompensa gerará:   
            //Quando o jogador assistir ao advertisement, o game ladeira abaixo dará a seguinte recompensa: destruiremos 3 árvores do início da fase 1 (MainScene)
            //Primeiramente instaciamos 3 GameObjects           
            Destroy(arvore1);
            Destroy(arvore2);
            Destroy(arvore3);
            //Zero o flag do advertisement
            _adDone = false;
        }

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
