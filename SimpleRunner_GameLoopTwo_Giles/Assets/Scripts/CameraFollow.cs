using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    
    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        transform.position = player.position + offset;
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
