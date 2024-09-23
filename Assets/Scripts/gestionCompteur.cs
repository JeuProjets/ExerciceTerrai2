using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionCompteur : MonoBehaviour
{
    public GameObject textCompteur;
    public int leCompteur;

    public void ActivationCompteur()
    {
        textCompteur.SetActive(true);
        StartCoroutine(decompte());
    }

    IEnumerator decompte()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            leCompteur--;
            
        }
    }
}
