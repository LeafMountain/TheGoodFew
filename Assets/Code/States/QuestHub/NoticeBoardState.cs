//Author: Axel Stenkrona
//Description: The state for the notice board in the middle of the town.
using Assets.Code.States.QuestHub;
using UnityEngine;

namespace Assets.Scripts.StateMachines.Hub
{
    namespace Assets.Code.Interfaces
    {

        public class NoticeBoardState : IHubStates
        {

            private HubStateMachine hubStateMachine;

            private GameObject menu;
            private Sprite[] characterPortraits;
            private Sprite[] menuVisuals;
            private AudioClip backGroundTrack;
            private string[] dialogueTexts;

            private NoticeBoardState() { }

            public NoticeBoardState(HubStateMachine hubStateMachine)
            {

            }

            public void MoveCamera()
            {

            }

            //properties

            public GameObject Menu { get; set; }
            public Sprite[] CharacterPortraits { get; set; }
            public Sprite[] MenuVisuals { get; set; }
            public AudioClip BackGroundTrack { get; set; }
            public string[] DialogueTexts { get; set; }
        }
    }
}