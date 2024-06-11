using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    private IHealth _health;

    private void OnEnable()
    {
        _health = GetComponent<IHealth>();
        _health.currentHealth += Change;
    }

    private void Change(int health)
    {
        if (health <= 0) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Погиб");
        _health.currentHealth -= Change;
    }
}
