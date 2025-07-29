using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator2D : MonoBehaviour
{

    [SerializeField] GameObject _cubePrefab;
    [SerializeField] private int _rows = 1;
    [SerializeField] private int _columns = 10;
    [SerializeField] private float _offsetX = 2.5f;
    [SerializeField] private float _offsetY = 0f;
    [SerializeField] private float _offsetZ = 0f;


    void Start()
    {
        if (_cubePrefab == null)
        {
            Debug.LogError($"Il Prefab del cubo non è stato assegnato nello script Instantiator2D su {gameObject}");
            return; 
        }

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Vector3 spawnPosition = transform.position + new Vector3(j * _offsetX, i * _offsetY, j * _offsetZ);

                Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
