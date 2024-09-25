using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deplacementHelico : MonoBehaviour
{
    public float vitesseAvant = 0.00f;
    public float vitesseAvantMax = 10000f;
    public float vitesseTourne = 1000f;
    public float vitesseMonte = 1000f;
    public float forceAcceleration;


    public GameObject refHeliceAvant;
    public GameObject refHeliceArriere;
    public GameObject refExplosion;
    public GameObject lumiereExplosion;
    public GameObject cameraDistanceFixe;
    public GameObject gestionnaireCameras;
    private Rigidbody rigidHelico;

    public bool finJeu;

    AudioSource sonHelico;

    // Start is called before the first frame update
    void Start()
    {
        rigidHelico = GetComponent<Rigidbody>();
        sonHelico = GetComponent<AudioSource>();
        
    }

   
    void FixedUpdate()
    {
        if(finJeu == false)
        {
            if (refHeliceAvant.GetComponent<tourneObjet>().vitesseRotation.y > 34)
            {
                if (sonHelico.isPlaying == false)
                {
                    sonHelico.Play();
                    // sonHelico.volume = refHeliceAvant.GetComponent<tourneObjet>().vitesseRotation;


                }
                rigidHelico.useGravity = false;

                float forceRotation = Input.GetAxis("Horizontal") * vitesseTourne;
                rigidHelico.AddRelativeTorque(0, forceRotation, 0);

                if (Input.GetKey(KeyCode.E) && vitesseAvant < vitesseAvantMax)
                {    
                    vitesseAvant += 100;
                }
                if (Input.GetKey(KeyCode.Q) && vitesseAvant >= 100)
                {
                    vitesseAvant -= 100;
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

    private void OnCollisionEnter(Collision collisionHelico)
    {
        
        if (collisionHelico.gameObject.name == "Terrain")
        {
            print("collision");
            finJeu = true;
            refExplosion.SetActive(true);
            lumiereExplosion.SetActive(true);
            
            rigidHelico.useGravity = true;
            rigidHelico.angularDrag = 1;
            rigidHelico.drag = 1/2;

            refHeliceAvant.GetComponent<tourneObjet>().moteurEnMarche = false;
            refHeliceArriere.GetComponent<tourneObjet>().moteurEnMarche = false;

            cameraDistanceFixe.SetActive(true);

            gestionnaireCameras.GetComponent<gestionCameras>().ActiverCamera(cameraDistanceFixe);
            Invoke("relancerScene", 8f);


        }

    }

    public void relancerScene()
    {
        SceneManager.LoadScene("deplacementHelico");
    }
}





