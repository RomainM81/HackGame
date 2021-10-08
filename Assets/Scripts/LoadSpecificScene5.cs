using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSpecificScene5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
          SceneManager.LoadScene("Stage_1");
        }
    }
}
