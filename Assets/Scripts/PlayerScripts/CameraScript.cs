using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y + 10f, 
            _player.transform.position.z), 1f);
    }
}
