using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSpecificScene4 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
          SceneManager.LoadScene("Aloy's stage");
        }
    }
}
