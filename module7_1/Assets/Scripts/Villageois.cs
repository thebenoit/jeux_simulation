using TMPro;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Villageois : MonoBehaviour
{
    private GameManager _gm;
    public int Or;
    public int Plantes;
    public int Roches;
    private int numeroRessourceChoisie = -1;
    private NavMeshAgent _navMeshAgent;

    private Strategie strategieChoix = new StrategieChoixHasard();
    public Strategie StrategieChoix
    {
        get { return strategieChoix; }
        set { strategieChoix = value; }
    }
    
    [SerializeField] private TMP_Text texteOr;
    [SerializeField] private TMP_Text textePlantes;
    [SerializeField] private TMP_Text texteRoches;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (numeroRessourceChoisie == -1)
        {
            
            ChoisirRessource();
        }

        else if (numeroRessourceChoisie != -1 && Vector3.Distance(_navMeshAgent.destination, transform.position) < 1.4f)
        {
            Debug.Log("Arrivée à la ressource" + numeroRessourceChoisie);
            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];
            Debug.Log("Ressource" + objet.name);

            var ressource = objet.GetComponent<Ressource>();
            if (ressource.Type == TypeRessource.Or)
                Or++;
            else if (ressource.Type == TypeRessource.Plante)
                Plantes++;
            else if (ressource.Type == TypeRessource.Roche)
                Roches++;

            MiseAJourTextes();
            
            GameManager.Instance.DetruireRessource(numeroRessourceChoisie);
            
            
            ChoisirRessource();
        }
    }

    private void MiseAJourTextes()
    {
        texteOr.text = "Or: " + Or;
        textePlantes.text = "Plantes: " + Plantes;
        texteRoches.text = "Roches: " + Roches;
    }

    public void ChangerStrategie(Strategie strategie)
    {
        Debug.Log("Changement de stratégie");
        this.strategieChoix = strategie;
        Debug.Log("Nouvelle stratégie: " + strategieChoix);
        ChoisirRessource();

    }

    private void ChoisirRessource()
    {
             
            // Choix au hasard
        int nbRessourcesDisponibles = GameManager.Instance.NbRessourcesDisponibles;

        if (nbRessourcesDisponibles == 0)
        {
            numeroRessourceChoisie = -1;
            Debug.Log("Aucune ressource disponible");
        }
        else
        {
            numeroRessourceChoisie = strategieChoix.ChoisirRessource(this, GameManager.Instance.Ressources, nbRessourcesDisponibles);
            Debug.Log("Ressource choisie: " + numeroRessourceChoisie);
            var objet = GameManager.Instance.Ressources[numeroRessourceChoisie];
            var ressource = objet.GetComponent<Ressource>();
            _navMeshAgent.destination = objet.transform.position;
        }
    }
}