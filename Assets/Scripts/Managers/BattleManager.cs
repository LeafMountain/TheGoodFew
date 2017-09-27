using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main hub for classes to find each other
public class BattleManager : MonoBehaviour {
    private static BattleManager battleManager;

    // public ItemDataBase itemDatabase { get; private set; }
    // public ClassDataBase classDatabase { get; private set; }

    public Board board { get; private set; }
    public MouseController mouse { get; private set; }
    public CameraControls cameraControls { get; private set; }

    // public TurnManager turnManager { get; private set; }
    // public AbilityManager abilitySystem { get; private set; }

    // public CombatStateMachine combatStateMachine { get; private set; }
    public GlobalStateMachine GlobalStateMachine { get; private set; }
    // public AIHelper aiHelper;

    private void Awake () {
        battleManager = this;

        //Initialize values
        // itemDatabase = new ItemDataBase ();
        // classDatabase = new ClassDataBase ();
        board = GameObject.FindObjectOfType (typeof (Board)) as Board;
        cameraControls = GameObject.FindObjectOfType (typeof (CameraControls)) as CameraControls;
        // aiHelper = new AIHelper ();
    }

    public static BattleManager GetInstance () {
        return battleManager;
    }

    private void Start () {
        //Initialize values
        mouse = GetComponent<MouseController> ();
        // abilitySystem = GameObject.FindObjectOfType (typeof (AbilityManager)) as AbilityManager;
        // turnManager = GetComponent<TurnManager>();
        

        GlobalStateMachine = GameObject.FindObjectOfType (typeof (GlobalStateMachine)) as GlobalStateMachine;

        // combatStateMachine = GetComponent<CombatStateMachine> ();
    }

    private void OnDisable(){
        battleManager = null;
    }
}