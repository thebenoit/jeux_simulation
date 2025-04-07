using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatPoursuite : EtatSquelette
{
   
   public EtatPoursuite(skeletonMouvement squelette, GameObject joueur) : base(squelette, joueur)
   {

   }
   public override void Enter()
   {
        Animateur.SetBool("Walk",true);
        Debug.Log("'Mode Poursuite Activée");
        AgentMouvement.destination = Joueur.transform.position;
   }

   public override void Handle(float deltaTime)
    {
        bool attaque_requise = false;
        
        if(!JoueurVisible())
        {
            skeletonMouvement mouvement = Squelette.GetComponent<skeletonMouvement>();
            mouvement.ChangerEtat(mouvement.Attente);
        }
        else
        {
            AgentMouvement.destination = Joueur.transform.position;
            attaque_requise = Vector3.Distance(Squelette.transform.position, Joueur.transform.position) <= 3.0f;
            
        }
        if(attaque_requise)
        {
            Squelette.ChangerEtat(new EtatAttaque(Squelette, Joueur));

        }
    }

    public override void Leave()
    {
        Animateur.SetBool("Walk",false);
    }
   
}
