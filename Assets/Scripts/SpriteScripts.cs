using UnityEngine;

public class SpriteScripts : MonoBehaviour
{
    [SerializeField] Camera _camera;
    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
