using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsRessources;
    [SerializeField] private int nbRessources;
    private string NomFichierSauvegarde;

    [SerializeField] private Strategie _strategieChoisie;


    public static GameManager Instance;
    public Ressource[] Ressources;
    public int NbRessourcesDisponibles { get; private set; }

    public Strategie StrategieChoisie
    {
        get { return _strategieChoisie; }
        set { _strategieChoisie = value; }
    }

    private void Awake()
    {
        NomFichierSauvegarde = Application.persistentDataPath + "/etat-jeu.json";
        // Valide qu'il y a un seul GameManager
        Debug.Assert(Instance == null);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        if(File.Exists(NomFichierSauvegarde))
        {
            Charger();
        }
        
            CreerRessources();
        

    }

     void OnApplicationQuit()
     {
        Sauvegarder();      
     }
    private void CreerRessources()
    {

        

        Ressources = new Ressource[nbRessources];
        // Cr�e les ressources au d�but du jeu
        for (int i = 0; i < nbRessources; i++)
        {
            float x = Random.value * 50 - 25;
            float z = Random.value * 50 - 25;
            Vector3 pos = new Vector3(x, 0.5f, z);
            int choix = Random.Range(0, prefabsRessources.Length);
            var objet = Instantiate(prefabsRessources[choix], pos, Quaternion.identity);
            Ressources[i] = objet.GetComponent<Ressource>();
        }

        NbRessourcesDisponibles = nbRessources;
    }



    // Update is called once per frame
    void Update()
    {
        if (NbRessourcesDisponibles == 0)
        {
            CreerRessources();
        }
    }

    private void onApplicationQuit()
    {
        Sauvegarder();
    }

    public void Sauvegarder()
    {
      var villageois = FindObjectOfType<Villageois>();

      EtatJeu etatJeu = new EtatJeu();
      
      etatJeu.Or = villageois.Or;
      etatJeu.Plantes = villageois.Plantes;
      etatJeu.Roches = villageois.Roches;

      etatJeu.NbRessourcesDisponibles = NbRessourcesDisponibles;

      string json = JsonUtility.ToJson(etatJeu);
      File.WriteAllText(NomFichierSauvegarde, json);
    }

    public void Charger()
    {
        var json = File.ReadAllText(NomFichierSauvegarde);

        EtatJeu etatJeu = JsonUtility.FromJson<EtatJeu>(json);

        var villageois = FindObjectOfType<Villageois>();
        villageois.Or = etatJeu.Or;
        villageois.Plantes = etatJeu.Plantes;
        villageois.Roches = etatJeu.Roches;
        NbRessourcesDisponibles = etatJeu.NbRessourcesDisponibles;

    }

    public void DetruireRessource(int numeroRessourceChoisie)
    {
        Destroy(Ressources[numeroRessourceChoisie].gameObject);

        // D�place le dernier objet dans cette case pour toujours
        // garder un tableau allant de 0 � NbRessourcesDisponibles
        //
        //  A B C D X Y Z  --> d�truire D
        //  A B C Z X Y null
        Ressources[numeroRessourceChoisie] = Ressources[NbRessourcesDisponibles - 1];
        Ressources[NbRessourcesDisponibles - 1] = null;
        NbRessourcesDisponibles--;
    }
}