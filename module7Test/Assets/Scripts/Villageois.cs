using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Villageois : MonoBehaviour
{
    public int Or = 0;
    public GameObject Objectif = null;

    private NavMeshAgent _navMeshAgent;
    [SerializeField] private TMP_Text texteOr;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Objectif == null)
        {
            Objectif = TrouverMeilleureRessource();

            if (Objectif != null && _navMeshAgent.enabled)
                _navMeshAgent.SetDestination(Objectif.transform.position);
        }
    }

    public GameObject TrouverMeilleureRessource()
    {
        var ressources = FindObjectsByType<Ressource>(FindObjectsSortMode.None);

        if (ressources.Length == 0)
            return null;

        int[] valeurs = new int[ressources.Length];
        for (int i = 0; i < ressources.Length; i++)
        {
            valeurs[i] = ressources[i].Valeur;
        }

        // �viter les n�gatifs: on veut chercher dans le tableau en �vitant le faux-or,
        // qui co�te plus cher � ramasser que ce que �a rapporte
        int indexDepart = 0;
        for (int i = 0; i < valeurs.Length; i++)
        {
            if (valeurs[i] < 0)
                indexDepart = i + 1;
        }

        // Choisir l'�l�ment qui a le plus de valeur comme prochain
        var index = Utilitaires.PlusGrandElementTableau(valeurs, indexDepart);

        return ressources[index].gameObject;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Ressource>(out var ressource))
        {
            Or += ressource.Valeur;
            MiseAJourUI();
            Destroy(other.gameObject);
        }
    }

    public void PerdreOr(int i)
    {
        Or -= i;
        MiseAJourUI();
    }

    private void MiseAJourUI()
    {
        if (texteOr != null)
            texteOr.text = "Or: " + Or;
    }
}