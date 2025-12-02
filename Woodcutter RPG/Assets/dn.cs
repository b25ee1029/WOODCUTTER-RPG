using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light Sun;
    public Light Moon;
    public float dayDuration = 300f; // 15 minutes full cycle
    private float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime / dayDuration;
        if (currentTime >= 1f) currentTime = 0f;

        float sunAngle = currentTime * 360f;
        Sun.transform.rotation = Quaternion.Euler(sunAngle, 0, 0);
        Moon.transform.rotation = Quaternion.Euler(sunAngle + 180f, 0, 0);

        float lightValue = Mathf.Clamp01(Mathf.Cos(currentTime * 2f * Mathf.PI));
        
        Sun.intensity = lightValue * 1.2f; // Full bright day
        Moon.intensity = (1f - lightValue) * 0.3f; // Dim night moon
    }
}
