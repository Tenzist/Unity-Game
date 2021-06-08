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
    public static bool movingobject;
    public Transform feetpos;
    public Transform hands;
    public float checkR;
    public LayerMask ground;
    public LayerMask wall;
 
    public GameObject Deathscreen;
    private bool death = false;
    public static Animator anim;
    public static bool FadeAnim = false;

 


    void Start()
    {
        anim = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        FadeAnim = false;
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
            anim.speed = 0f;
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
        {
            if (grounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetTrigger("is jump");
            }
            if (grounded == true)
            {
                anim.SetBool("is jump", false);
            }
            else
            {
                anim.SetBool("is jump", true);
            }
        }
        if (death == true)
        {
            if (Input.anyKey)
            {
                Restart();
            }
        }
        movingobject = Physics2D.OverlapCircle(hands.position, checkR, ground);
        {
            if (movingobject == true && moveInput != 0f && grounded == true)
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {
                        Moving();
                }
            }
            else NotMoving();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            FadeAnim = true;
            Invoke("NextLevel", 1f);
        }
        if (this.CompareTag("Player") && other.CompareTag("MapEnd"))
        {
            Deathscreen.SetActive(true);    
            Invoke("deathtrue", 1f);
            anim.Play("dieanim");
        }
    }
    public void Moving()
    {
        Audio.aud.pitch = 0.4f;
        anim.speed = 0.3f;
    }
    public void NotMoving()
    {
        anim.speed = 1f;
        Audio.aud.pitch = 1f;
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
        //Debug.Log("Loading Next level");
        PauseMenu.lvlNum++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
