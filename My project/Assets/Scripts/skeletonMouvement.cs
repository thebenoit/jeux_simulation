using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonMouvement : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsPatrouille;
    private UnityEngine.AI.NavMeshAgent _agent;
    private int _indexPatrouille;
    private Animator _animator;

    private EtatSquelette _etat;

    public EtatPatrouille Patrouille { get; private set; }
    public EtatPoursuite Poursuite { get; private set; }
    public EtatAttente Attente { get; private set; }

    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _indexPatrouille = 0;
        _agent.destination = _pointsPatrouille[_indexPatrouille].position;
        _animator = GetComponent<Animator>();
        GameObject joueur = GameObject.FindGameObjectWithTag("Player");
        Patrouille = new EtatPatrouille(this, joueur, _pointsPatrouille);
        Poursuite = new EtatPoursuite(this, joueur);
        Attente = new EtatAttente(this, joueur);

        _etat = Patrouille;
        _etat.Enter();
    }

    // Update is called once per frame
    void Update()
    {

        _etat.Handle(Time.deltaTime);
 /*       _animator.SetBool("Walk",true);
        if (!_agent.pathPending)
        {
            if(_agent.remainingDistance <= 0.1f)
            {
                //definir la destination suivante 
                _agent.destination = _pointsPatrouille[_indexPatrouille].position;
                //changer l'index de la destination
                _indexPatrouille = (_indexPatrouille + 1) % _pointsPatrouille.Length;
                
            }
        }
    }*/


    }

    public void ChangerEtat(EtatSquelette nouvelEtat)
    {
        _etat.Leave();
        _etat = nouvelEtat;
        _etat.Enter();
    }
}
