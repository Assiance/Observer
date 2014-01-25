using System.Collections;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public enum LightKarma { Good, Bad, Neutral }
    public LightKarma currentLightKarma = LightKarma.Neutral;

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
                RenderSettings.fogDensity = BadFogDensity;
                RenderSettings.ambientLight = BadAmbience;
                break;
            case LightKarma.Neutral:
                RenderSettings.fogDensity = NeutralFogDensity;
                RenderSettings.ambientLight = NeutralAmbience;
                break;
            case LightKarma.Good:
                RenderSettings.fogDensity = GoodFogDensity;
                RenderSettings.ambientLight = GoodAmbience;
                break;
        }
    }
}
