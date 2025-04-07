using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatPatrouille : EtatSquelette
{
    private int _pointIndex;
    private List<Transform> _pointsPatrouille;
    // Start is called before the first frame update
    public EtatPatrouille(MouvementSquelette p_squelette, GameObject joueur, Transform[] points) : base(p_squelette, joueur)
    {
       _points = points;
       _indexPatrouille = 0; 
    }

    public override void Handle(float deltaTime)
    {
        if(! AgentMouvement.pathPending)
        {
          if (AgentMouvement.remainingDistance <= 0.1f)
          {
            AgentMouvement.destination = _pointsPatrouille[_indexPatrouille].position;
            _indexPatrouille = (_indexPatrouille + 1) % _points.Length;
          }
        }

        if(JoueurVisible())
        {
            MouvementSquelette mouvement = Squelette.GetComponent<MouvementSquelette>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }
    }

    public override void Leave()
    {
        AnimatorSetBool("Walk",false);
    }

    // Update is called once per frame
}
