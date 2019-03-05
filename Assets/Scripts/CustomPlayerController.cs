using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CustomPlayerController : MonoBehaviour
{
    public AudioClip collectedIgnot;
    public AudioClip hitByEnemy;
    public AudioClip victory;
    public AudioClip fall;
    public int numberOfIgnots;

    private AudioSource audioSource;
    private bool isGameOver;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isGameOver = false;
    }

    void PlayClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isGameOver) return;
        GameObject gameObject = other.gameObject;
        if (gameObject.CompareTag("Enemy"))
        {
            OnHitByEnemy(gameObject);
        }
        else if (gameObject.CompareTag("Ignot"))
        {
            OnCollectedIgnot(gameObject);
        }
        else if (gameObject.CompareTag("Subground"))
        {
            OnFall();
        }
    }

    void OnHitByEnemy(GameObject enemy)
    {
        Destroy(enemy);
        PlayClip(hitByEnemy);
        StartCoroutine(EndGameHitByEnemy());
        isGameOver = true;
    }

    void OnCollectedIgnot(GameObject ignot) {
        Destroy(ignot);
        if (--numberOfIgnots == 0)
        {
            isGameOver = true;
            PlayClip(victory);
            StartCoroutine(EndGameForVictory());
        }
        else
        {
            PlayClip(collectedIgnot);
        }
    }

    void OnFall()
    {
        PlayClip(fall);
        StartCoroutine(EndGameFall());
    }

    IEnumerator EndGameHitByEnemy()
    {
        yield return new WaitForSeconds(hitByEnemy.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator EndGameFall()
    {
        yield return new WaitForSeconds(fall.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator EndGameForVictory()
    {
        yield return new WaitForSeconds(victory.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
