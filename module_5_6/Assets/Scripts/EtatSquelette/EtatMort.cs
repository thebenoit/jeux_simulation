using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatMort : EtatSquelette
{
    private float tempsAvantDetruire = 2.0f;
    private float tempsEcoule = 0.0f;

    public EtatMort(skeletonMouvement mouvementSquelette, GameObject joueur) : base(mouvementSquelette, joueur)
    {
        AgentMouvement.enabled = false;

    }
    public override void Enter()
    {
        GameObject.Destroy(Squelette.GetComponent<Collider>()); // évite que le squelette soit touché quand il est mort
    }

    public override void Handle(float deltaTime)
    {
        tempsEcoule += deltaTime;
        // faire tourner le squelette
        Squelette.transform.Rotate(Vector3.up, 180.0f * deltaTime);
        if(tempsEcoule >= tempsAvantDetruire)
        {
            GameObject.Destroy(Squelette.gameObject);
        }
    }
    // Start is called before the first frame update
    public override void Leave()
    {
        
    }
}
