using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasReleasedTrigger;
    private System.Random random = new System.Random();

    protected abstract OVRInput.Axis1D IndexTrigger();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hasReleasedTrigger = true;
    }

    void Update()
    {
        float trigger = OVRInput.Get(IndexTrigger());
        if (trigger < 0.1)
        {
            hasReleasedTrigger = true;
        }
        if (trigger > 0.9 && hasReleasedTrigger && !audioSource.isPlaying)
        {
            hasReleasedTrigger = false;
            audioSource.Play();
            RaycastGun();
        }
    }

    private void RaycastGun()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            GameObject gameObject = hit.collider.gameObject;
            if (gameObject.CompareTag("Enemy"))
            {
                gameObject.GetComponent<EnemyController>().OnHit();
            }
        }
    }
}
