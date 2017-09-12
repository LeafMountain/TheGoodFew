using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateStory : StateMachineState {

    private CombatStateMachine combatStateMachine;
    private Dialogue dialogue;
    private int currentIndex;
    private GameObject dialogueBox;
    private InputManager inputManager;

    public CombatStateStory (CombatStateMachine combatStateMachine, Dialogue dialogue, int currentIndex) {
        this.combatStateMachine = combatStateMachine;
        this.dialogue = dialogue;
        this.currentIndex = currentIndex;
        this.inputManager = InputManager.GetInstance();

        //If a dialogue exists make unit say line
        if (dialogue != null) {
            SayLine(dialogue.lines[currentIndex]);
        }
        //Go to turn state
        else {
            combatStateMachine.ChangeState(new CombatStateTurn(combatStateMachine));
        }

        inputManager.NextPressed += Next;
    }

    //Makes a unit show a speech bubble with text in
    private void SayLine (Line line) {
        ObjectInformation fromUnit = FindUnitByName(line.name);
        CameraControls cc = GameObject.FindObjectOfType(typeof(CameraControls)) as CameraControls;
        cc.Move(fromUnit.gameObject.transform.position);

        dialogueBox = new SpeechBubble(fromUnit, line.line).gameObject;
    }

    //Find unit in scene
    private ObjectInformation FindUnitByName (string name) {
        List<ObjectInformation> units = new List<ObjectInformation>();
        units.AddRange(GameObject.FindObjectsOfType(typeof(ObjectInformation)) as ObjectInformation[]);

        for (int i = 0; i < units.Count; i++) {
            if (units[i].unitName == name)
                return units[i];
        }

        return null;

    }

    //Go to next state
    private void Next () {
        inputManager.NextPressed -= Next;
        
        if (currentIndex + 1 < dialogue.lines.Count)
            combatStateMachine.ChangeState(new CombatStateStory(combatStateMachine, dialogue, currentIndex + 1));
        else
            combatStateMachine.NextState();

        if (dialogueBox != null)
            GameObject.Destroy(dialogueBox);
    }
}