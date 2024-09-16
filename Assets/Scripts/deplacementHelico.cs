using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacementHelico : MonoBehaviour
{
    public float vitesseAvant = 0f;
    public float vitesseAvantMax = 10000f;
    public float vitesseTourne = 1000f;
    public float vitesseMonte = 1000f;
    public float forceAcceleration;


    public GameObject refHeliceAvant;
    private Rigidbody rigidHelico;

    public bool finJeu;

    // Start is called before the first frame update
    void Start()
    {
        rigidHelico = GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
        if (refHeliceAvant.GetComponent<tourneObjet>().moteurEnMarche)
        {
            rigidHelico.useGravity = false;

            float forceRotation = Input.GetAxis("Horizontal") * vitesseTourne;
            rigidHelico.AddRelativeTorque(0f, forceRotation, 0f, ForceMode.Impulse);

            if (Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax)
            {    
                vitesseAvant += forceAcceleration;
            }
            if (Input.GetKey(KeyCode.Q) && vitesseAvant > 0f)
            {
                vitesseAvant -= forceAcceleration;
            }


            float forceMonte = Input.GetAxis("Vertical") * vitesseMonte;
            GetComponent<Rigidbody>().AddRelativeForce(0f, forceMonte, vitesseAvant);

            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
        }
        else
        {
            rigidHelico.useGravity = true;
        }

    }
}



