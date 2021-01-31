using UnityEngine;

[CreateAssetMenu(menuName = "State Machines/State", fileName = "New State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    public void DoActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    public void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionResult = transitions[i].decision.Decide(controller);
            if(decisionResult)
                controller.TransitionToState(transitions[i].trueState);
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}