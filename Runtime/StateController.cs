using UnityEngine;

public class StateController : MonoBehaviour
{
    public bool aiActive = true;
    public State currentState = null;
    public State remainState;

    private void Start()
    {
        for (int i = 0; i < currentState.actions.Length; i++)
        {
            currentState.actions[i].StartAction(this);
        }
        for (int i = 0; i < currentState.transitions.Length; i++)
        {
            currentState.transitions[i].decision.Init(this);
        }
    }

    private void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState){
            for (int i = 0; i < currentState.actions.Length; i++)
            {
                currentState.actions[i].EndAction(this);
            }
            for (int i = 0; i < currentState.transitions.Length; i++)
            {
                currentState.transitions[i].decision.CleanUp(this);
            }
                
            currentState = nextState;
            for (int i = 0; i < currentState.transitions.Length; i++)
            {
                currentState.transitions[i].decision.Init(this);
            }
            for (int i = 0; i < currentState.actions.Length; i++)
            {
                currentState.actions[i].StartAction(this);
            }
        }
    }
}