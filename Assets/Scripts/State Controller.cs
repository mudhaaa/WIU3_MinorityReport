using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class StateController : MonoBehaviour
{
    public State currentState;

    public Transform eyes;
    public State remainState;


    [SerializeField] public DialogSystem dialogSystem;
    [SerializeField] public SceneFunctions sceneFunctions;
    [SerializeField] public float lookSphereCastRadius = 2f;
    [SerializeField] public float attackRange = 1.5f;
    [SerializeField] public Transform chaseTarget;
    [SerializeField] public Transform attackPos;
    [SerializeField] public CharacterRenderer characterRenderer;
    [SerializeField] public PlayerMainController playerstatus;
    [SerializeField] public bool gotHit;

    public bool aiActive = true;
    public bool flip;

    public DialogSystem pDialogSystem;

    // Waypoint system
    [SerializeField] public List<Transform> wayPointList = new List<Transform>();
    [SerializeField] public int nextWayPoint = 0;
    public float moveSpeed = 2f;



    public Path path;
    public Seeker seeker;
    public Rigidbody2D rb;

    public void SetupAI(bool aiActivationFromManager)
    {
       
        if (aiActive)
        {
            gameObject.SetActive(true);

        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    private void Start()
    {

        SetupAI(aiActive);
        // Find the player object in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            chaseTarget = player.transform;
        }
        else
        {
            Debug.LogError("No player object found in the scene!");
        }
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();


    }


    void Update()
    {
        if (!aiActive || pDialogSystem.IsCompleted() == false)
        {
            return;
        }
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, lookSphereCastRadius);
        }

    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMainController>().Died = true;
            dialogSystem.onDialogEnd += sceneFunctions.LoadGeneralBE;
            GameManager.Instance.IsEndingCompleted[0] = true;
            dialogSystem.FilePath = "Assets/Dialog/GeneralBadEnding.txt";
            dialogSystem.StartNewDialogues();
        }
    }
}
