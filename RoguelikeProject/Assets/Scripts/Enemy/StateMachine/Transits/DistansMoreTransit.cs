using UnityEngine;

public class DistansMoreTransit : Transition
{
    [SerializeField] private float _transitionRange;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
