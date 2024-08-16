using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopLock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float StartLockRotationSpeed = 50.0f;
    [SerializeField] float LockRotationSpeed = 1.0f;
    [SerializeField] float SpeedMultiplier = 1.0f;
    [SerializeField] GameObject Stick;
    void Start()
    {
        LockRotationSpeed = StartLockRotationSpeed;
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + (Time.deltaTime * LockRotationSpeed * SpeedMultiplier));
    }
}
