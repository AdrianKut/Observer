using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private GameObject _particleEffect;

    public void InstantiateColoredEffect(Color color)
    {
        GameObject newEffect = Instantiate(_particleEffect, gameObject.transform.position, Quaternion.identity);
        newEffect.GetComponent<Renderer>().material.color = color;

        var destroyDelay = newEffect.GetComponent<ParticleSystem>().main.duration;

        Destroy(newEffect, destroyDelay);    
    }
}