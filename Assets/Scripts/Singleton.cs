using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Singleton>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(Singleton).Name);
                    instance = singletonObject.AddComponent<Singleton>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
