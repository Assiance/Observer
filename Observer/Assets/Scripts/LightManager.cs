using System.Collections;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public enum LightKarma { Good, Bad, Neutral }
    public LightKarma currentLightKarma = LightKarma.Neutral;
    public float FadeTime = 0;

    public int BadValue;
    public int GoodValue;

    public float BadFogDensity;
    public float NeutralFogDensity;
    public float GoodFogDensity;

    public Color BadAmbience;
    public Color NeutralAmbience;
    public Color GoodAmbience;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ChangeDown"))
        {
            SceneManager.Instance.Karma += -1;
        }

        if (Input.GetButtonDown("ChangeUp"))
        {
            SceneManager.Instance.Karma += 1;
        }

        if (SceneManager.Instance.Karma <= BadValue)
        {
            currentLightKarma = LightKarma.Bad;
        }
        else if (SceneManager.Instance.Karma >= GoodValue)
        {
            currentLightKarma = LightKarma.Good;
        }
        else
        {
            currentLightKarma = LightKarma.Neutral;
        }
    }

    void LateUpdate()
    {
        switch (currentLightKarma)
        {
            case LightKarma.Bad:
                StartCoroutine(Fade(RenderSettings.fogDensity, BadFogDensity, RenderSettings.ambientLight, BadAmbience, FadeTime));
                break;
            case LightKarma.Neutral:
                StartCoroutine(Fade(RenderSettings.fogDensity, NeutralFogDensity, RenderSettings.ambientLight, NeutralAmbience, FadeTime));
                break;
            case LightKarma.Good:
                StartCoroutine(Fade(RenderSettings.fogDensity, GoodFogDensity, RenderSettings.ambientLight, GoodAmbience, FadeTime));
                break;
        }
    }

    IEnumerator Fade(float currentDensity, float targetDensity, Color currentAmbience, Color targetAmbience, float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            RenderSettings.ambientLight = Color.Lerp(currentAmbience, targetAmbience, (elapsedTime / time));
            RenderSettings.fogDensity = Mathf.Lerp(currentDensity, targetDensity, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }
}
