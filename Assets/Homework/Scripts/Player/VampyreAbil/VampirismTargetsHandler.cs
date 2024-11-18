using System.Collections.Generic;
using UnityEngine;

public class VampirismTargetsHandler : MonoBehaviour
{
    [SerializeField] private AreaActionVampire _area;

    private List<EnemyHealth> _enemies = new List<EnemyHealth>();

    private void OnEnable()
    {
        _area.DetectedTarget += Add;
        _area.LeavedTarget += Remove;
    }

    private void OnDisable()
    {
        _area.DetectedTarget -= Add;
        _area.LeavedTarget -= Remove;
    }

    public EnemyHealth Get(PlayerHealth player)
    {
        EnemyHealth target = null;

        if (_enemies.Count > 0)
            target = Selection(player);

        return target;
    }

    public void Remove(EnemyHealth enemy)
    {
        if (_enemies.Contains(enemy))
            _enemies.Remove(enemy);
    }

    private EnemyHealth Selection(PlayerHealth player)
    {
        EnemyHealth target = null;
        float distance = 100f;
        float minDistance = distance;

        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] != null)
                minDistance = Vector2.Distance(player.transform.position, _enemies[i].transform.position);

            if (distance > minDistance)
            {
                distance = minDistance;
                target = _enemies[i];
            }
        }

        return target;
    }

    public void Clear()
    {
        _enemies = new List<EnemyHealth>();
    }

    private void Add(EnemyHealth enemy)
    {
        if (enemy != null && _enemies.Contains(enemy) == false)
            _enemies.Add(enemy);
    }
}
