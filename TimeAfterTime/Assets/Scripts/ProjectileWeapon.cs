using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectileObject;
    
    private Transform _playerTransform;

    private GameObject _projectile;

    private void Start()
    {
        _playerTransform = transform;
        CreateProjectile(projectileObject, _playerTransform);
    }

    private void DestroyProjectile()
    {
    }

    private void CreateProjectile(GameObject projectileObject, Transform playerTransform) {
        Instantiate(projectileObject, playerTransform.position, playerTransform.rotation);
        
    } 
}
