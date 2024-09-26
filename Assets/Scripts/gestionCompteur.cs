using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Compteur2 : MonoBehaviour
{
    public TextMeshProUGUI textCompteur;
    public int valCompteur = 3;

    public GameObject helicoptere;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Comptage", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(valCompteur == 0)
        {
            textCompteur.gameObject.SetActive(false);

            CancelInvoke();
        }
    }

    void Comptage()
    {
        valCompteur--;
        textCompteur.text = valCompteur.ToString();

        if (valCompteur == 0)
        {
            helicoptere.GetComponent<deplacementHelico>().ExploserHelico();
        }
    }
}
