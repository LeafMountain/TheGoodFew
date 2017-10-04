using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent (typeof (NavMeshAgent))]
public class GridMover : MonoBehaviour {

    private NavMeshAgent agent;

    private int moveRange;
    private Vector3 destination;
    public Vector3 Destination {
        get { return new Vector3 (destination.x, transform.position.y, destination.z); }
        private set {
            agent.SetDestination (value);
            StopAllCoroutines();
            StartCoroutine ("CorrectPosition"); 
            StartCoroutine ("CheckIfReachedDestination");           
            destination = value;
        }
    }

    [TooltipAttribute ("The time until the object is forced to the destinations position")] public float timeoutTime = 5;

    public FloatEvent Moving = new FloatEvent ();
    public UnityEvent ReachedDestination = new UnityEvent ();

    //Velocity
    private Vector3 lastPosition;
    private float lastVelocity;
    private float velocity { get { return (transform.position - lastPosition).magnitude / Time.deltaTime; } }

    public AI ai;
    public bool AtDestination { get { return (Vector3.Distance (transform.position, Destination) < 0.1f + agent.stoppingDistance); } }

    private void Awake () {
        agent = GetComponent<NavMeshAgent> ();
        Destination = transform.position;
        ReachedDestination.RemoveAllListeners();
    }

    private void Start(){
        ObjectInformation objectInformation = GetComponent<ObjectInformation>();

        if(objectInformation != null){
            moveRange = objectInformation.UnitData.Movement;
        }

        ShowMoveableArea();        
    }

    //Move to destination
    public void Move (Vector3 destination) {
        this.Destination = destination;
    }

    //Updates the velocity of the object
    private void UpdateVelocity () {
        if (velocity != lastVelocity) {
            OnMoving ();
            lastVelocity = velocity;
            lastPosition = transform.position;
        }
    }

    //Invokes an event when moving and sends out the velocity of the gameobject
    public void OnMoving () {
        if (Moving != null) {
            Moving.Invoke (velocity);
        }
    }

    //Invokes an event when the gameobject has reaced its destination
    public void OnReachedDestination () {
        if (ReachedDestination != null) {
            ReachedDestination.Invoke ();
        }
    }

    public void ShowMoveableArea(){
        Grid grid = new Grid(1, Color.red, GetMoveableTiles(GetMoveArea()));
        grid.UpdateGrid();
    }

    public List<GridCell> GetMoveArea(){
        List<GridCell> moveArea = new List<GridCell>();

        for (int x = -moveRange; x <= moveRange; x++){
            for (int y = -moveRange; y <= moveRange; y++){
                Vector2 newCell = new Vector2(destination.x + x, destination.z + y);
                moveArea.Add(new GridCell(newCell, Grid.CellType.neutral));
            }
        }
        
        return moveArea;   
    }

    public List<GridCell> GetMoveableTiles(List<GridCell> moveArea){
        List<GridCell> moveableTiles = new List<GridCell>();

        //Pathfinding

        
        return moveableTiles;
    }

    //If the gameobject hasn't reached its destination in timeoutTime, teleport the gameobject to the destinatnion
    //Failsafe
    IEnumerator CorrectPosition () {
        yield return new WaitForSeconds (timeoutTime);

        if (!AtDestination) {
            transform.position = Destination;
        }
    }

    //When the destination has been reached, trigger the OnReachedDestination method.
    IEnumerator CheckIfReachedDestination(){
        if(!AtDestination){
            yield return null;
        }

        OnReachedDestination();
    }

    public void Update () {
        UpdateVelocity ();
    }
}