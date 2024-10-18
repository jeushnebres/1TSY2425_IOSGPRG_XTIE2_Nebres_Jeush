using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _curHealth;
    [SerializeField] float _maxHealth;

    [SerializeField] bool _isAlive = false;
    public bool IsAlive {  get { return _isAlive; } }

	private void Awake()
	{
        GameManager.Instance.Player = this;
	}

	public void PlayerStart()
    {
        _maxHealth = 100;
        _curHealth = _maxHealth;
        _isAlive = true;
    }

    public void Movement(Vector3 direction)
    {
        this.transform.position += direction;
    }

    public void TakeDamage(float damage, GameObject objDamager)
    {
        if (!_isAlive) return;
        _curHealth -= damage;
        Debug.Log("Player Take Damage: " + damage + " : Damager: " + objDamager.name);

        if (_curHealth <= 0)
        {
            _isAlive = false;
            Die();
        }

        SpawnerController.Instance.RemoveEnemy(objDamager);
    }

    public void Die()
    {
        GameManager.Instance.GameOver();
        Debug.Log("Game Over!");
    }
    public void Reset()
	{
		_maxHealth = 100;
		_curHealth = _maxHealth;
		_isAlive = true;
	}
}