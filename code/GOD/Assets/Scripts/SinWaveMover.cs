using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveMover : MonoBehaviour
{
    void Start()
    {
        m_centerPosition = transform.position;
        m_speed = Random.Range(0.1f, 0.5f);
        m_amplitude = Random.Range(0.1f, 0.5f);
        m_period = Random.Range(1.0f, 2.0f);
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;
        m_speed = Random.Range(0.0f, 2.0f);

        // Move center along x axis
        m_centerPosition.y -= deltaTime * m_speed;

        // Update degrees
        float degreesPerSecond = 360.0f / m_period;
        m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
        float radians = m_degrees * Mathf.Deg2Rad;

        // Offset by sin wave
        Vector3 offset = new Vector3(m_amplitude * Mathf.Sin(radians), 0.0f, 0.0f);
        transform.position = m_centerPosition + offset;
    }

    Vector3 m_centerPosition;
    float m_degrees;

    [SerializeField]
    float m_speed = 1.0f;

    [SerializeField]
    float m_amplitude = 1.0f;

    [SerializeField]
    float m_period = 1.0f;
}
