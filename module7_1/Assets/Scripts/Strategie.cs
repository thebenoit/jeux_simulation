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
        Debug.Log("Choix de la ressource au hasard");
       return Random.Range(0, nbRessourcesDisponibles);
    }
    
}
public class StrategieChoixPlusProche : Strategie
{
    public override int ChoisirRessource( Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        Debug.Log("Choix de la ressource la plus proche");
      int indexMin = 0;
      float distanceMin = Vector3.Distance(villageois.transform.position, ressources[0].transform.position);

      for (int i = 1; i < nbRessourcesDisponibles; i++)
      {
        var distance = Vector3.Distance(ressources[i].transform.position, villageois.transform.position);
        if (distance < distanceMin)
        {
            distanceMin = distance;
            indexMin = i;
        }
      }   

      return indexMin;
    }       

}
public class StrategieChoixEquilibre : Strategie
{
    public override int ChoisirRessource( Villageois villageois, Ressource[] ressources, int nbRessourcesDisponibles)
    {
        Debug.Log("Choix de la ressource la plus Equilibre");
        int indexMax = 0;
        float distanceMax = Vector3.Distance(ressources[0].transform.position, villageois.transform.position);
        float valeurMax = ressources[0].Valeur / (distanceMax * distanceMax);

       for (int i = 1; i < nbRessourcesDisponibles; i++)
       {
        var distance = Vector3.Distance(ressources[i].transform.position,villageois.transform.position);
        float valeurSelonDistance = ressources[i].Valeur / (distance * distance);

        if (valeurSelonDistance > valeurMax)
        {
            valeurMax = valeurSelonDistance;
            indexMax = i;
        }
       }
       return indexMax;
        
    }
}
