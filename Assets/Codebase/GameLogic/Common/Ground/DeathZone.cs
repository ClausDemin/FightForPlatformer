using Assets.Codebase.GameLogic.Common;
using Assets.Codebase.GameLogic.Common.HealthBehavior;
using UnityEngine;

[RequireComponent(typeof(CollisionChecker))]
public class DeathZone : MonoBehaviour
{
    private CollisionChecker _checker;

    private void Awake()
    {
        _checker = GetComponent<CollisionChecker>();
    }

    private void Start()
    {
        _checker.TriggerEntered += Kill;
    }

    private void Kill(Collider2D collision) 
    {
        if (collision.gameObject.TryGetComponent(out HealthComponent health)) 
        {
            health.TakeDamage(health.Current);
        } 
    }

    private void OnDestroy()
    {
        _checker.TriggerEntered -= Kill;
    }
}
