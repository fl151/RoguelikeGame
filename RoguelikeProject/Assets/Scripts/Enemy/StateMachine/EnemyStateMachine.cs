using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private bool _canTransit = true;

    public Player Target { get; private set; }

    private void Start()
    {
        Target = GetComponent<Enemy>().Target;

        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null || _canTransit == false)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    public void StopTransits()
    {
        _canTransit = false;
    }

    public void StartTransits()
    {
        _canTransit = true;
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
