using System;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    [SerializeField] private Mat[] mats;
    [SerializeField] private Renderer playerVisuals;

    public static ColorManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance.playerVisuals = playerVisuals;
            Destroy(gameObject);
        }
    }
    public void ChangeColor(string name)
    {
        Mat m = Array.Find(mats, x => x.name == name);

        if (m == null)
        {
            Debug.Log("Material not found " + name);
            return;
        }

        playerVisuals.material = m.material;
        playerVisuals.gameObject.layer = (int)m.layer;

    }
}
