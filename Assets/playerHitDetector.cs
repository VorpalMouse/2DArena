using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerHitDetector : MonoBehaviour
{
    public float playerTotalHealth;
    public float playerCurrentHealth;
    public bool isInKeySpot;
    public Slider mySlider;
    public cameraShake cameraShaker;
    [SerializeField]
    private Image myHealth;
    private bool justHit;
    private float justHitTimer;
    void start()
    {
        isInKeySpot = false;
        justHit = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "canBeHit")
        {
            if (!justHit)
            {
                playerCurrentHealth--;
                justHit = true;
                justHitTimer = 1;
                StartCoroutine(cameraShaker.shake(.05f, .3f));
                if (playerCurrentHealth == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        if (collision.gameObject.tag == "keySpot")
        {
            isInKeySpot = true;
            mySlider.gameObject.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "keySpot")
        {
            isInKeySpot = false;
            mySlider.gameObject.SetActive(false);
            mySlider.value = 0f;
        }
    }
    void Update()
    {
        myHealth.fillAmount = playerCurrentHealth / playerTotalHealth;
        if (Input.GetKey(KeyCode.E)&&mySlider.value == mySlider.maxValue)
        {
        }
        else if (Input.GetKey(KeyCode.E) && isInKeySpot)
        {
            mySlider.value += .001f;
            StartCoroutine(cameraShaker.shake(.01f, .03f));
        }
        else
        {
            mySlider.value -= .001f;
        }
        if (justHit)
        {
            justHitTimer -= .005f;
        }
        if (justHitTimer < 0)
        {
            justHit = false;
        }
    }
}
