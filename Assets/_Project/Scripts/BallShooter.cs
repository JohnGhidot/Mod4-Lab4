using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _shotForce = 10f;
    [SerializeField] private float _ballLifeTime = 3f;
    [SerializeField] private float _ballRadius = 0.5f;

    private Camera _mainCamera;


    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }

    private void ShootBall()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.SphereCast(ray, _ballRadius, out hit, 100f))
        {
            if (hit.collider.CompareTag(("Wall")))
            {
                Debug.Log("Il raggio ha colpito un muro grigio! Impossibile sparare.");
                return;
            }
        }

        GameObject ball = Instantiate(_ballPrefab, _mainCamera.transform.position, Quaternion.identity);

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        Vector3 shootDirection = ray.direction.normalized;

        rb.AddForce(shootDirection * _shotForce, ForceMode.Impulse);

        Destroy(ball, _ballLifeTime);


    }
}
