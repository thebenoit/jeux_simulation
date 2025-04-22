using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Strategie
{
  public abstract int ChoisirRessource(GameObject[] ressources, Transform villageois);
}

public class StrategieChoixHasard : Strategie
{

}
public class StrategieChoixPlusProche : Strategie
{

}
public class StrategieChoixEquilibre : Strategie
{

}
