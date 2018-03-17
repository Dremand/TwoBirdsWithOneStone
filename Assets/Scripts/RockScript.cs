using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockScript : MonoBehaviour {

    public static RockScript instance;

    [SerializeField]
    private Rigidbody2D thisRB;
    [SerializeField]
    private Animator anim;
    private float forwardSpeed = 3f;
    private float balanceSpeed = 4f;
    private bool didRoll;
    public bool isAlive;
    private Button throwStoneButton;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip throwRockSound, pointClip, dieSound;

    public int score;

    private void Awake()
    {
     if (instance == null)
        {
            instance = this;
        }
        isAlive = true;
        score = 0;

        throwStoneButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        throwStoneButton.onClick.AddListener(() => RollTheRock());

        SetCamsX();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isAlive)
        {
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if(didRoll)
            {
                didRoll = false;
                thisRB.velocity = new Vector2(0, balanceSpeed);
                audioSource.PlayOneShot(throwRockSound);
                anim.SetTrigger("Roll");
            }
            if(thisRB.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -thisRB.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
	}

    void SetCamsX()
    {
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public void RollTheRock()
    {
        didRoll = true;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")
        {
            if(isAlive)
            {
                isAlive = false;
                anim.SetTrigger("Death");
                audioSource.PlayOneShot(dieSound);
                GamePlayController.instance.PlayerDiedShowScore(score);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHolder")
        {
            score++;
            GamePlayController.instance.SetScore(score);
            audioSource.PlayOneShot(pointClip);
        }
    }

}
