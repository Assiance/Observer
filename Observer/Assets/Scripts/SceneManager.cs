using UnityEngine;


public class SceneManager : MonoBehaviour
{
    #region Singleton

    private static SceneManager _instance;

    public static SceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(SceneManager)) as SceneManager;

                if (_instance == null)
                {
                    _instance = new GameObject("SceneManager Temporary Instance", typeof(SceneManager)).GetComponent<SceneManager>();
                }

                _instance.Init();
            }

            return _instance;
        }
    }

    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _instance.Init();
        }
    }

    #endregion

    public int Karma = 0;
    public GameObject PlayerOVRCamera;
    public GameObject Player;

    private void Init()
    {
    }
}