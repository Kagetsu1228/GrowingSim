
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public delegate void Tick();
    public static event Tick OnTick;

    [SerializeField]
    private int RefreshRate;
    
    private static GameManger _instance;
    public static GameManger Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Update()
    {
        if (Time.frameCount % RefreshRate == 0)
        {
            OnTick?.Invoke();
        }
    }

    private void OnEnable()
    {
        
    }
}
