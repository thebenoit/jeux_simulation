using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatAttaque : EtatSquelette
{
    // Start is called before the first frame update
    public EtatAttaque(MouvementSquelette p_squelette, GameObject joueur) : base(p_squelette, joueur)
    {

    }
    public override void Enter()
    {
        Animateur.SetBool("Attack",true);
    }
    public override void Handle(float deltaTime)
    {

    }

    public override void Leave()
    {
        Animateur.SetBool("Attack",false);
    }
}
