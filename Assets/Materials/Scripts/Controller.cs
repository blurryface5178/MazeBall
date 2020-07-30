using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
   // AudioSource sound;
    private Rigidbody rb;
    public float speed;
    private int count = 0;
    public Text countText;
    public Text EndText;
    private IEnumerator Final;
    public Text timevalue;
    private float currentTime;
    public AudioClip PickUp;
    public AudioClip DontPickUp;
    public AudioClip FallDown;
    public AudioClip notyet;
    public AudioClip Win;
    private AudioSource sound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        countText.text = "Start Game";
        EndText.text = "";
        Vector3 start_pos = new Vector3(-9.0f, 1f, -9.0f);
        GetComponent<Rigidbody>().position = start_pos;
       // obj = GetComponent<AudioSource>();
        Time.timeScale = 1;
        currentTime = 0f;
        sound = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
       //float moveHorizontal = Input.acceleration.x;
       //float moveVertical = Input.acceleration.y;
       
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        rb.AddForce(movement * speed);

        currentTime += 1 * Time.deltaTime;
        timevalue.text = "Time: " + currentTime.ToString("0.00");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count:" + count.ToString();
            sound.clip = PickUp;
            sound.Play();
        }

        if (other.gameObject.CompareTag("Final"))
        {
            if (count == 6)
            {
                other.gameObject.SetActive(false);
                EndText.text = "You win!";
                Time.timeScale = 0;
                sound.clip = Win;
                sound.Play();
            }
            else
            {
                Final = NotYet(2.0f);
                StartCoroutine(Final);
            }
        }

        if (other.gameObject.CompareTag("DontPickUp"))
        {
            EndText.text = "You lost!";
            Time.timeScale = 0;
            other.gameObject.SetActive(false);
            sound.clip = DontPickUp;
            sound.Play();
            //gameObject.StopAnimation();
        }
              
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            EndText.text = "You lost!";
            Time.timeScale = 0;
            sound.clip = FallDown;
            sound.Play();
        }
        
    }

    private IEnumerator NotYet(float t)
    {
            EndText.text = "You haven't finished all the objectives yet";
            yield return new WaitForSeconds(t);
            EndText.text = "";
            sound.clip = notyet;
            sound.Play();
        }

 }