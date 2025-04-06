using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonMouvement : MonoBehaviour
{
    [SerializeField] private Transform[] _pointsPatrouille;
    private UnityEngine.AI.NavMeshAgent _agent;
    private int _indexPatrouille;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _indexPatrouille = 0;
        _agent.destination = _pointsPatrouille[_indexPatrouille].position;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("Walk",true);
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
    }
}
