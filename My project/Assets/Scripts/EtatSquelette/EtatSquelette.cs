using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EtatSquelette 
{
    // Start is called before the first frame update
    public MouvementSquelette Squelette{get; set;}
    public GameObject Joueur{get; set;}
    public UnityEngine.AI.NavMeshAgent AgentMouvement{get; set;}
    public Animator Animateur{get; set;}

    public EtatSquelette(MouvementSquelette p_squelette, GameObject p_joueur)
    {
        Squelette = Squelette;
        Joueur = Joueur;
        AgentMouvement = Squelette.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Animateur = squelette.GetComponent<Animator>();
    }

    protected bool JoueurVisible()
    {
        bool visible = false;
        RaycastHit hit;

        //PATCH: on place les y au meme niveau eviter les probleme.
        Vector3 positionJoueur = new Vector3(Joueur.transform.position.x, 0.5f, Joueur.transform.position.z);
        Vector3 positionSquelette = new Vector3(Squelette.transform.position.x, 0.5f, Squelette.transform.position.z);
        Vector3 directionJoueur = positionJoueur - positionSquelette;

        //Regarde s'il y a un obstacle entre le squelette et le joueur.
        if(Physics.Raycast(positionSquelette,directionJoueur, out hit))
        {

            if(hit.transform == Joueur.transform)
            {
            //Il n'y a pas d'obstacle, on vérifie l'angle
            float angle = Vector3.Angle(Squelette.transform.forward, directionJoueur);
            visible = angle <= 40.0f;
            }

        }
        return visible;
    }

    public abstract void Enter();
    public abstract void Handle(float deltaTime);
    public abstract void Leave();
    
}
