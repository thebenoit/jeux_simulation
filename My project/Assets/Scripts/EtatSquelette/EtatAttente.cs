using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatAttente : EtatSquelette
{

    private float _tempAttente;
    // Start is called before the first frame update
    public EtatAttente(skeletonMouvement p_squelette, GameObject joueur) : base(p_squelette, joueur)
    {
        _tempAttente = 0.0f;
    }
    public override void Enter()
    {
        _tempAttente = UnityEngine.Random.Range(3.0f, 5.0f);
        AgentMouvement.destination = Squelette.transform.position;
    }
    public override void Handle(float deltaTime)
    {
        _tempAttente -= deltaTime;
        if(_tempAttente <= 0.0f)
        {
            skeletonMouvement mouvement = Squelette.GetComponent<skeletonMouvement>();
            mouvement.ChangerEtat(mouvement.Patrouille);
        } 
        else if (JoueurVisible())
        {
            skeletonMouvement mouvement = Squelette.GetComponent<skeletonMouvement>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }
    }
    public override void Leave()
    {
        
    }

    // Update is called once per frame
}
