using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;
    public float ResetTime = 0;
    public Image HPGage;

    public GameObject Effect;
    public AudioSource audioSource;
    public AudioClip HitSE;

    Collider collider;

    public string TagName;

    void Start()
    {
        collider = GetComponent<Collider>();
    }
    private void Update()
    {
        if (HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);
            effect.transform.position = transform.position;
            Destroy(effect, 5);
            Destroy(Main);
        }

        float percent = (float)HP / MaxHP;
        HPGage.fillAmount = percent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagName)
        {
            Damage();
            collider.enabled = false;
            Invoke("ColliderReSet", ResetTime);
        }
    }

    void Damage()
    {
        audioSource.PlayOneShot(HitSE);
        HP--;
    }

    void ColliderReSet()
    {
        collider.enabled = true;
    }
}
