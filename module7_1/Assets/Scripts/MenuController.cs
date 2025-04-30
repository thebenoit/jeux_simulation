using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuiController : MonoBehaviour
{
    [SerializeField] private Button _boutonHasard;
    [SerializeField] private Button _boutonPlusProche;
    [SerializeField] private Button _boutonEquilibre;
    private GameManager gm;

    private Villageois villageois;
    private int strategieChoisie = 1;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        villageois = GameObject.FindObjectOfType<Villageois>();
    }

    public void cliquerHasard()
    {
        Debug.Log("Choix de la ressource au hasard");
         villageois.ChangerStrategie(new StrategieChoixHasard());
    }

    public void cliquerLePlusProche()
    {
        Debug.Log("Choix de la ressource la plus proche");
        villageois.ChangerStrategie(new StrategieChoixPlusProche());
    }

    public void cliquerEquilibre()
    {
        Debug.Log("Choix de la ressource la plus Equilibre");
         villageois.ChangerStrategie(new StrategieChoixEquilibre());
    }
     

     void OnApplicationQuit()
     {
        int idStrategie = 0;

        if(villageois.StrategieChoix is StrategieChoixHasard)
            idStrategie = 0;
        else if(villageois.StrategieChoix is StrategieChoixPlusProche)
            idStrategie = 1;
        else if(villageois.StrategieChoix is StrategieChoixEquilibre)
            idStrategie = 2;

        PlayerPrefs.SetInt("StrategieChoixRessource", idStrategie);
     }
    public void ChargerStrategie()
    {
        int id = PlayerPrefs.GetInt("StrategieChoixRessource",0);

        print("Stratégie rechargée: " + id);

        if(id == 0)
        {
            villageois.ChangerStrategie(new StrategieChoixHasard());
        }
        else if(id == 1)
        {
            villageois.ChangerStrategie(new StrategieChoixPlusProche());
        }
        else if(id == 2)
        {
            villageois.ChangerStrategie(new StrategieChoixEquilibre());
        }
    }
 

    // Update is called once per frame
    void Update()
    {

    }
}
