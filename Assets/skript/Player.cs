using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public static float moveInput;
    private Rigidbody2D rb;
    private bool faceR = true;

    public static bool grounded;
    public Transform feetpos;
    public float checkR;
    public LayerMask ground;
 
    public GameObject Deathscreen;
    private bool death = false;
    public static Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
    }
    void Flip()
    {
        faceR = !faceR;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (faceR == true && moveInput < 0)
        {
            Flip();
        }
        if (faceR == false && moveInput > 0)
        {
            Flip();
        }
        if (moveInput == 0)
        {
            anim.SetBool("is walk", false);
        }
        else
        {
            anim.SetBool("is walk", true);
        }
    }
    private void Update()
    {

        grounded = Physics2D.OverlapCircle(feetpos.position, checkR, ground);
        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetTrigger("is jump");
                
        }
        if(grounded == true)
        {
            anim.SetBool("is jump", false);
        }
        else
        {
            anim.SetBool("is jump", true);
        }
        if (death == true)
        {
            if (Input.anyKey)
            {
                Restart();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            NextLevel();
            //Invoke("NextLevel", 3f);

        }
        if (this.CompareTag("Player") && other.CompareTag("MapEnd"))
        {
            Deathscreen.SetActive(true);    
            Invoke("deathtrue", 1f);
            anim.Play("dieanim");
        }
    }
    void deathtrue()
    {
        death = true;
        Time.timeScale = 0.05f;
        Invoke("Restart", 0.6f);


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        PauseMenu.lvlNum++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
