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
    private int strategieChoisie = 1;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void cliquerHasard()
    {
         gm.StrategieChoisie = new StrategieChoixHasard();
    }

    public void cliquerLePlusProche()
    {
        gm.StrategieChoisie = new StrategieChoixPlusProche();
    }

    public void cliquerEquilibre()
    {
         gm.StrategieChoisie = new StrategieChoixEquilibre();
    }
 

    // Update is called once per frame
    void Update()
    {

    }
}
