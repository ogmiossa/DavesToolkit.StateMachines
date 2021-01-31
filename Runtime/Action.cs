using UnityEngine;

public abstract class Action : ScriptableObject
{
    public virtual void StartAction(StateController controller) { }

    public virtual void Act(StateController controller) { }
    
    public virtual void EndAction(StateController controller) { }
}