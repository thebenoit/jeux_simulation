using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;
    [SerializeField] private Slider _barreDeVie;
    [SerializeField] private AudioSource _sonProjectile;

    private int _pointsDeVie;
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;
        _camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _barreDeVie.value = (float)_pointsDeVie / _pointsDeVieMax;
    }

    void LateUpdate()
    {
        if (_camera == null)
        {
            _camera = FindObjectOfType<Camera>();
            if (_camera == null)
            {
                Debug.LogError("Aucune caméra trouvée dans la scène!");
                return;
            }
        }

        if (_barreDeVie != null)
        {
            _barreDeVie.transform.LookAt(_camera.transform);
        }
    }

    public void RetirerPointsDeVie(int dommages)
    {
        _pointsDeVie -= dommages;
        if (_pointsDeVie <= 0)
        {
           skeletonMouvement mourant = GetComponent<skeletonMouvement>();
           GetComponent<skeletonMouvement>().ChangerEtat(new EtatMort(mourant, null)); 
        }
    }
}
