using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ScannerEnemie : MonoBehaviour
{
    private CircleCollider2D _circleCollider2D;
    private List<Ghost> _ghosts = new List<Ghost>();

    private void Awake()
    {
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ghost ghost))
        {
            _ghosts.Add(ghost);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ghost ghost))
        {
            _ghosts.Remove(ghost);
        }
    }

    public Ghost FindNearestGhost(Vector2 position)
    {
        Ghost nearestGhost = null;
        float nearestDistance = float.MaxValue;

        foreach (Ghost ghost in _ghosts)
        {
            if (ghost == null) 
            {
                continue;
            }
                
            float distance = Vector2.Distance(position, ghost.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestGhost = ghost;
            }
        }

        return nearestGhost;
    }
}