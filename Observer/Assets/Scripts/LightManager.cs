using System.Collections;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    

    [Range(0,1)]
    public float FadeTime = 0;

    public int MaxValue;
    

    public float BadFogDensity = .5f;
    public float NeutralFogDensity = .3f;
    public float GoodFogDensity = .1f;

    public Color BadAmbience = Color.red;
    public Color NeutralAmbience =Color.black;
    public Color GoodAmbience = Color.blue;
    
    private float _currentKarma =0;

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

        float KarmaDiff = SceneManager.Instance.Karma - _currentKarma;
        
        //Linear
        //KarmaDiff = (Mathf.Sign(KarmaDiff) * FadeTime);
        //_currentKarma += KarmaDiff;
        // exponential
        _currentKarma += (KarmaDiff /10 * FadeTime);
        float LerpVal = Mathf.Abs(_currentKarma / (float)MaxValue);

        if (_currentKarma < 0) RenderSettings.ambientLight = Color.Lerp(NeutralAmbience, BadAmbience, LerpVal);
        if (_currentKarma > 0) RenderSettings.ambientLight = Color.Lerp(NeutralAmbience, GoodAmbience, LerpVal);
        if (_currentKarma == 0) RenderSettings.ambientLight = NeutralAmbience;
        RenderSettings.fogDensity = Mathf.Lerp(BadFogDensity, GoodFogDensity, (_currentKarma + (float)MaxValue)/ (2 * (float)MaxValue));
        
    }

    void LateUpdate()
    {
        
    }

    //IEnumerator Fade(float currentDensity, float targetDensity, Color currentAmbience, Color targetAmbience, float time)
    //{
    //    float elapsedTime = 0;
    //    while (elapsedTime < time)
    //    {
    //        RenderSettings.ambientLight = Color.Lerp(currentAmbience, targetAmbience, (elapsedTime / time));
    //        RenderSettings.fogDensity = Mathf.Lerp(currentDensity, targetDensity, (elapsedTime / time));
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //}
}
