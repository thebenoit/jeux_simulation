using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatPatrouille : EtatSquelette
{
    private int _pointIndex;
    private Transform[] _pointsPatrouille;
    // Start is called before the first frame update
    public EtatPatrouille(skeletonMouvement p_squelette, GameObject joueur, Transform[] points) : base(p_squelette, joueur)
    {
       _pointsPatrouille = points;
       _pointIndex = 0; 
    }

    public override void Enter()
    {
        Animateur.SetBool("Walk",true);
    }

    public override void Handle(float deltaTime)
    {
        if(! AgentMouvement.pathPending)
        {
          if (AgentMouvement.remainingDistance <= 0.1f)
          {
            AgentMouvement.destination = _pointsPatrouille[_pointIndex].position;
            _pointIndex = (_pointIndex + 1) % _pointsPatrouille.Length;
          }
        }
        //si le joueur est visible, on change d'etat
        if(JoueurVisible())
        {
            skeletonMouvement mouvement = Squelette.GetComponent<skeletonMouvement>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Walk",false);
    }

    // Update is called once per frame
}
