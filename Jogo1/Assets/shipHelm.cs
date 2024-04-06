using UnityEngine;

public class shipHelm : MonoBehaviour
{
    [SerializeField] public GameManager.Scene nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(nextLevel);
        }
    }
}
