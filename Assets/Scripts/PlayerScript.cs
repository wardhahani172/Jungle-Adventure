using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    // untuk mengatur kecepatan saat Player bergerak
    [SerializeField] private float speed;
    // untuk komponen rigidbody2D
    private Rigidbody2D rigidBody;
    // untuk menyimpan nilai yang mengkondisikan
    // player saat bergerak ke kanan atau ke kiri
    private float moveInput;
    // untuk mengkondisikan benar saat player menghadap ke kanan
    private bool facingRight;
    // untuk mendapatkan koin
    public int points;


    // memberi nilai seberapa tinggi player dapat melompat
    [SerializeField] private float jumpForce;
    // menandakan benar jika player menyentuh pinjakan atau tanah
    [SerializeField] private bool isGrounded;
    // memastikan bahwa posisi kaki player berada di bawah
    // semacam telapak kaki
    [SerializeField] private Transform feetPos;
    // ini digunakan untuk mengatur seberapa besar radius kaki player
    [SerializeField] private float circleRadius;
    // ini digunakan untuk memastikan object
    // yang bertindak atau dijadikan sebagai tanah
    [SerializeField] private LayerMask whatIsGround;

    // untuk menjalankan animasi idle, run, dan jump
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
       // inisialisasi komponen rigidbody2D yang ada pada player
       rigidBody = GetComponent<Rigidbody2D>();
       // set di awal benar karena player menghadap ke kanan
       facingRight = true;
       // inisialisasi komponen animator yang ada pada player
       anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    private void Update()
    {
       // dengan memanggil class physics2D dan fungsi overlapcircle
       // yg memiliki 3 parameter ini menandakan bahwa
       // isGrounded akan bernilai benar jika ke-3 parameter tersebut terpenuhi
       isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius, whatIsGround);

       // fungsi untuk player saat melompat
       CharacterJump(); 
    }

    private void FixedUpdate (){
        // fungsi yg memanage inputan
        // saat player bergerak ke kanan atau ke kiri
        CharacterMovement();
        // fungsi yang mengatur
        // transisi animasi player
        // saat idle, run, atau jump
        CharacterAnimation();
  
    }



    private void CharacterMovement(){
        // input.GetAxis adalah sebuah fungsi
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0 && facingRight == false)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight == true)
        {
            // fungsi yg berguna agar player dapat menghadap ke kanan/kiri
            Flip();
        }
        // nilai pada sumbu X akan bertambah sesuai dg speed * moveInput
        rigidBody.velocity = new Vector2(speed * moveInput, rigidBody.velocity.y);
    }

    void CharacterJump(){

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            // cara panggil animasi dengan parameter yg bertipe Trigger
            anim.SetTrigger("isJump");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }

    void CharacterAnimation()
    {
        if (moveInput != 0 && isGrounded == true)
        {
            // cara memanggil animasi dg parameter yg bertipe Bool
            anim.SetBool("isRun", true);

        } else if (moveInput == 0 && isGrounded == true)
        {
            anim.SetBool("isRun", false);
        }
    }

    private void Flip()
    {
        // facingRight bernilai tidak sama dengan facingRight
        facingRight = !facingRight;
        // membuat variabel dg tipe Vector3
        // (scaling pada sumbu x=1, y=1, z=1)
        Vector3 scaler = transform.localScale;
        // kemudian nilai pada sumbu x dikalikan dengan minus
        scaler.x *=-1;
        // sumbu x pada player diberi nilai minus sehingga saat player menghadap kiri sumbu x pada player bernilai -1
        transform.localScale = scaler;
    }
}


