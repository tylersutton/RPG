using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D myRigidBody;

	private bool playerMoving;
	public Vector2 lastMove;
	private static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

    public static GameObject playerStart;
	public string startPoint;
	public string theScene, theSceneDark;

	public Vector3 moving;
	Scene currScene;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		playerStart = GameObject.Find("StartPoint");
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
			DontDestroyOnLoad(playerStart.transform.gameObject);
		}
		else {
			Destroy(gameObject);
		}
		currScene = SceneManager.GetActiveScene();
		theScene = currScene.name;
		theSceneDark = currScene.name + "Dark";
	}
	
	// Update is called once per frame
	void Update () {
		currScene = SceneManager.GetActiveScene();
		playerMoving = false;
		if (!attacking) {
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
				myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
				moving = myRigidBody.velocity;
			}
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
				moving = myRigidBody.velocity;
			}
			if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) {
				myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
				moving = myRigidBody.velocity;
			}
			if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f) {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
				moving = myRigidBody.velocity;
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				attackTimeCounter = attackTime;
				attacking = true;
				//myRigidBody.velocity = Vector2.zero;
				anim.SetBool("Attack", true);
			}
			if (Input.GetKeyDown(KeyCode.Tab)) {
				if (currScene.name == theScene && SceneUtility.GetBuildIndexByScenePath(theSceneDark) >= 0) {
					SceneManager.LoadScene(theSceneDark, LoadSceneMode.Single);
				}
				else if (currScene.name == theSceneDark) {
					SceneManager.LoadScene(theScene, LoadSceneMode.Single);	
				}
				myRigidBody.velocity = moving;
				startPoint = "StartPoint";
			}

			if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;			}
			else {
				currentMoveSpeed = moveSpeed;
			}
		}

		if (attackTimeCounter >= 0) {
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool("Attack", false);
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));	
		anim.SetBool("Moving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}
}