using UnityEngine;

public abstract class Decision : ScriptableObject
{
    public virtual void Init(StateController controller){}
    public abstract bool Decide(StateController controller);
    public virtual void CleanUp(StateController controller){}
}