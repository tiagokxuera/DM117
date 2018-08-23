using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SE A PLATAFORMA A EXECUTAR O JOGO SUPORTA ADS (ADVERTISEMENTS <ANÚNCIOS/PROPAGANDA>)
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class AdControlBehavior : MonoBehaviour {

    //ATRIBUTO ESTÁTICO QUE DEFINE SE A AD VAI SER APRESENTADA (TRUE) OU NÃO (FALSE)
    public static bool showAds = true;

    //ATRIBUTO ESTÁTICO QUE DEFINE O INTERVALO DE EXIBIÇÃO ENTRE ANÚNCIOS
    public static DateTime? nextRewardAdTime = null;

    public static void ShowRewardAd() {
        #if UNITY_ADS
            //CONFIGURANDO OPÇÕES DA PROPAGANDA (PARA PAUSAR O JOGO QUANDO O ANÚNCIO SURGIR)
            ShowOptions options = new ShowOptions();
            options.resultCallback = Unpause;
            //DEFININDO O DELTA-TEMPO-EM-SEGUNDOS PARA A POSSÍVEL GERAÇÃO DE UM NOVO ANÚNCIO <UNITY3D.COM RECOMENDA 25 ADs / DIA .:. 24*60*60, ENTÃO GERAREMOS 1 AD / HORA>
            //ALTERAR LINHA ABAIXO PARA CASO QUEIRA TESTAR A FEATURE EM UM MENOR INTERVALO DE TEMPO <e.g. 20 segundos: nextRewardAdTime = DateTime.Now.AddSeconds(20);>
            nextRewardAdTime = DateTime.Now.AddHours(1);

            //SE O ANÚNCIO ESTIVER PRONTO PARA SER EXIBIDO, O EXIBE
            if (Advertisement.IsReady()) {
                Advertisement.Show(options);
            }

            //PAUSANDO O JOGO ENQUANTO O ANÚNCIO ESTIVER SENDO EXIBIDO
            MainSceneBehavior._isPaused = true; //!!! TIAGO PRECISARÁ IMPLEMENTAR !!!
            Time.timeScale = 0; //!!! TIAGO PRECISARÁ IMPLEMENTAR !!!
        #endif
    }

#if UNITY_ADS
    public static void Unpause(ShowResult result) {
        //DESPAUSA O JOGO QUANDO O ANÚNCIO ENCERRAR
        MainSceneBehavior._isPaused = false; //!!! TIAGO PRECISARÁ IMPLEMENTAR !!!
        Time.timeScale = 1f; //!!! TIAGO PRECISARÁ IMPLEMENTAR !!!
    }
#endif

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
