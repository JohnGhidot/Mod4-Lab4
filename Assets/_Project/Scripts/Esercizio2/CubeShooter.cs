using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeShooter : MonoBehaviour
{

    [SerializeField] private float _shotForce = 10f;
    [SerializeField] private GameObject _BulletHolePrefab;
    [SerializeField] private float _bulletHoleSize = 0.1f;



    private Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootCube();
        }
    }

    private void ShootCube()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 shotDirection = ray.direction.normalized;

                rb.AddForceAtPosition(shotDirection * _shotForce, hit.point, ForceMode.Impulse);

                if (_BulletHolePrefab != null)
                {
                    Quaternion holeRotation = Quaternion.LookRotation(-hit.normal);
                    Vector3 spawnPos = hit.point + hit.normal * 0.001f;
                    GameObject bulletHole = Instantiate(_BulletHolePrefab, spawnPos, holeRotation, hit.transform);
                }

            }
        }
    }
}
