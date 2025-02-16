using UnityEngine;

public class Player : MonoBehaviour
{
    // buat variabel untuk akses sprite
    private SpriteRenderer spriteRenderer;
    // buat array sprite
    public Sprite[] sprites;
    // buat variabel index sprite untuk track indeksnya
    private int spriteIndex;
    private Vector3 direction;
    // buat public agar muncul di editor unity hub
    public float gravity = -9.8f;
    public float strength = 5f;

    // awake = function yg dijalankan sebelum start
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // InvokeRepeating = function yg dijalankan berulang-ulang
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // function otomatis yg dijalankan pertama kali
    private void Update(){
        // getmousebuttondown(0) = klik kiri mouse
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            // jika player klik maka player akan melompat
            direction = Vector3.up * strength;
        }
        // jika ada sentuhan lebih dari 0
        if(Input.touchCount > 0){
            // touch objek, 0 adlaah index awal artinya sentuhan paling pertama
            Touch touch = Input.GetTouch(0);
            // jika ada sentuhan yg dimulai
            if(touch.phase == TouchPhase.Began){
                // player akan bergerak keatas
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    // function untuk animasi sprite
    private void AnimateSprite(){
        // spriteIndex = indeks sprite
        spriteIndex++;
        // jika spriteIndex lebih besar dari panjang array sprites
        if(spriteIndex >= sprites.Length){
            // maka spriteIndex akan kembali ke 0
            spriteIndex = 0;
        }
        // panggil spriteRenderer dan ganti sprite sesuai indeks spriteIndex
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
        }else if(other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
            
        }
    }
}
