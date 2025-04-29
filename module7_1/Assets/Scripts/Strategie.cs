using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Strategie
{
    public abstract int ChoisirRessource( Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles);
}

public class StrategieChoixHasard : Strategie
{
   
    //    private int numeroRessourceChoisie = -1;

    public override int ChoisirRessource( Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
       return Random.Range(0, nbRessourcesDisponibles);
    }
    
}
public class StrategieChoixPlusProche : Strategie
{
    public override int ChoisirRessource( Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        Debug.Log("Choix de la ressource la plus proche");
        float minDistance = float.MaxValue;
        return numeroRessourceChoisie = -1;  
        
        
    }       

}
public class StrategieChoixEquilibre : Strategie
{
    public override int ChoisirRessource( Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        Debug.Log("Choix de la ressource la plus Equilibre");
        float minDistance = float.MaxValue;
        return numeroRessourceChoisie = -1;  
        
        
    }
}
