public class TargetDeadTransition : Transition
{
    private void Update()
    {
        if (Target.gameObject.activeSelf == false)
        {
            NeedTransit = true;
        }
    }
}
