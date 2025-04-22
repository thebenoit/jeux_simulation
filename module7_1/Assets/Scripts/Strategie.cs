using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Strategie
{
    int ChoisirRessource(GameObject[] ressources, Transform villageois);
}

class StrategieChoixHasard : Strategie
{

}
class StrategieChoixPlusProche : Strategie
{

}
class StrategieChoixEquilibre : Strategie
{

}
