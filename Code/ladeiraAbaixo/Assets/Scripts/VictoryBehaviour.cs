using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryBehaviour : MonoBehaviour {
    //Referência para a tela inicial (InitialScene)
    private static string _INITIALSCENE = "InitialScene";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// MÉTODO DISPARADO PELO CLIQUE NO BOTÃO "REINICIAR". CARREGA A TELA INICIAL DO JOGO
    /// </summary>
    public void LoadInitialScene()
    {
        #if UNITY_ADS
            //SE O ANÚNCIO ESTIVER PRONTO PARA SER EXIBIDO, O EXIBE
            if (AdControlBehavior.showAds) {
                AdControlBehavior.ShowRewardAd();
            }
        #endif
        SceneManager.LoadScene(_INITIALSCENE);
    }
}
