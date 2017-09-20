//Author: Axel Stenkrona
//Description: StateMachine for the Hub.
using Assets.Scripts.StateMachines.Hub.Assets.Code.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.States.QuestHub
{   

public class HubStateMachine : MonoBehaviour {

    protected IHubStates currentHubState;

        private GameObject[] subHubsButtons;
        private List<IHubStates> subHubs;


        void Start()
        {
            subHubsButtons = GetSubHubs(gameObject.transform.childCount);


            currentHubState = new OverViewState(this);
        }

    public void ChangeHubState(string newState)
    {
          if(newState == "Tavern") { currentHubState = new TavernState(this);}
          if(newState == "NoticeBoard") { currentHubState = new NoticeBoardState(this); }
          if(newState == "BlackSmith") { currentHubState = new BlackSmithState(this); }
          if(newState == "OverView") { currentHubState = new OverViewState(this); }
    }
        //Gets all the gameobjects that are children to the gameobject this class is attached to.
        public GameObject[] GetSubHubs(int length)
        {
            GameObject[] array = new GameObject[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = gameObject.transform.GetChild(i).gameObject;
            }
            return array;
        }

        //Properties
        public List<IHubStates> SubHubs { get { return subHubs; } set { subHubs = value; } }
        

}
}
