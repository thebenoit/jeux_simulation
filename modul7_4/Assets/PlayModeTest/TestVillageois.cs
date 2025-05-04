using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEditor;
using System.Linq;

public class TestVillageois
{
   private GameObject prefabOr, prefabPiege;
   private GameObject villageois;

   [SetUp]
   public void CreerObjets()
   {
    var prefabVillageois = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Villageois.prefab");

    villageois = GameObject.Instantiate(prefabVillageois,new Vector3(0,0,0), Quaternion.identity);

    prefabOr = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Or.prefab");
    prefabPiege = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Piege.prefab");
   }

   [TearDown]
   public void DetruireObjets()
   {
    GameObject.DestroyImmediate(villageois);

    foreach(var ressource in GameObject.FindObjectsOfType<Ressource>())
    {
        GameObject.DestroyImmediate(ressource.gameObject);
    }

    foreach(var piege in GameObject.FindObjectsOfType<Piege>())
    {
        GameObject.DestroyImmediate(piege.gameObject);
    }
   }

   [UnityTest]
   public IEnumerator ObjectifPlusGrandeValeur_Simple()
   {
    // ARRANGE
    var or1  = GameObject.Instantiate(prefabOr, new Vector3(10,0,10),Quaternion.identity);
    var or2 = GameObject.Instantiate(prefabOr, new Vector3(10,0,0),Quaternion.identity);
    var or3 = GameObject.Instantiate(prefabOr, new Vector3(0,0,10),Quaternion.identity);
    var or4 = GameObject.Instantiate(prefabOr, new Vector3(5,0,5),Quaternion.identity);

    or1.GetComponent<Ressource>().Valeur = 10;
    or2.GetComponent<Ressource>().Valeur = 20;
    or3.GetComponent<Ressource>().Valeur = 30;
    or4.GetComponent<Ressource>().Valeur = 15;

    // ACT
    yield return null;
    
    var objectif = villageois.GetComponent<Villageois>().Objectif;

    //ASSERT
    Assert.AreSame(or3,objectif);
   }

   [UnityTest]
   public IEnumerator ObjectifPlusGrandeValeur_PlusRien()
   {
    yield return null;
    // ARRANGE
    var objectif = villageois.GetComponent<Villageois>().Objectif;

    //ASSERT
    Assert.IsTrue(objectif == null);
   }

}
