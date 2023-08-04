using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{

    private AudioSource audioSource;
    public Button bt;
    private Rigidbody rg;
    public Text finishtext,time,hearth;
    string fnshtext;
    private bool isItfinish = false;
    private Vector3 force;
    float totalTime = 15;
    int totalhearth = 3;
    // Start is called before the first frame update
    void Start()
    {

        hearth.text = totalhearth + "";
        rg= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isItfinish)
        {
            totalTime -= Time.deltaTime;
            time.text = (int)totalTime + "";
        }

        if(totalTime <= 0 ) { 
            isItfinish= true;
            finishtext.text = "Time's Up!";
            bt.gameObject.SetActive(true);
        }

        
    }

    private void FixedUpdate()
    {
        if (isItfinish == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            force = new Vector3(horizontal, 0, vertical);
            rg.AddForce(force * 4);
        }
        else
        {
            rg.velocity= Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
        
    }

    private void OnCollisionEnter(Collision collision) { 

        string objectname = collision.gameObject.name;

        

        if (objectname.Equals("FinishGround"))
        {
            
            fnshtext = "Game Complate!";
            finishtext.text = fnshtext;
            isItfinish = true;
            bt.gameObject.SetActive(true);

        }
        else if(!objectname.Equals("Ground") && !objectname.Equals("Plane"))
        {
            // Çarpýþma sesini çal
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            totalhearth -= 1;
            hearth.text = totalhearth.ToString();

            if (totalhearth == 0)
            {
                isItfinish = true;
                finishtext.text = " Game Finished!";
                bt.gameObject.SetActive(true);
            }
        }
    }

    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
