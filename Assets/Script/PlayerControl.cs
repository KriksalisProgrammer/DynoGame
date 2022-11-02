using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{

    public bool _Dead = false;
    public AudioClip jumpSound;
    public AudioClip kickSound;
    public AudioClip gameOver;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;


    private bool _isOnGround = true;
    private int score;

    
    private Rigidbody2D _rb;
    private Animator _playerAnimator;
    private AudioSource playerAudio;
    private MainAudio mainAudio;


    [SerializeField]private float _jumpForce;
    [SerializeField]private float gravityModifier;

    void Start()
    {
        
        _rb=GetComponent<Rigidbody2D>();
        _playerAnimator=GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        mainAudio = GameObject.Find("Main Camera").GetComponent<MainAudio>();
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isOnGround && !_Dead)
        {
            
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            UpdateScore(5);
            _playerAnimator.SetBool("Jump", true);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(kickSound, 1.0f);
            mainAudio.GameOver();
            _playerAnimator.SetBool("Dead", true);
            _Dead = true;
            playerAudio.PlayOneShot(gameOver, 1.0f);
            GameOver();
        }
        
    }
    private void Jump()
    {
        _playerAnimator.SetBool("Jump", false);
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        _isOnGround = false;
    }

    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    private void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }
    
}
