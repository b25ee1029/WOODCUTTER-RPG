using UnityEngine;

public class myDayNightCycle : MonoBehaviour
{
    [Header("Lights")]
    public Light sun;
    public Light moon;

    [Header("Cycle Settings")]
    public float dayDurationInMinutes = 5f;
    public AnimationCurve lightCurve; // for smooth transition
    
    private float rotationSpeed;

    void Start()
    {
        // Full 360° rotation in the given duration
        rotationSpeed = 360f / (dayDurationInMinutes * 60f);
    }

    void Update()
    {
        // Rotate the Sun continuously
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        // Sun height relative to horizon (-1 to 1)
        float dot = Vector3.Dot(sun.transform.forward, Vector3.down);

        // Use curve to fade intensity
        float lightAmount = Mathf.Clamp01(dot);

        sun.intensity = lightCurve.Evaluate(lightAmount) * 1.2f;
        moon.intensity = lightCurve.Evaluate(1f - lightAmount) * 0.4f;

        // Enable/Disable shadows smoothly
        sun.shadows = sun.intensity > 0.1f ? LightShadows.Soft : LightShadows.None;
        moon.shadows = moon.intensity > 0.05f ? LightShadows.Soft : LightShadows.None;
    }
}
