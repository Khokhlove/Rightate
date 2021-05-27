using System.Collections.Generic;
using UnityEngine;

public class SelectionResult : MonoBehaviour
{
    public List<ParticleSystem> particles;
    public enum ResultType {correct, incorrect}

    static SelectionResult instance;
    void Awake()
    {
        instance = this;
    }
    public static SelectionResult GetInstance()
    {
        return instance;
    }
    public void CreateParticle(ResultType result, Vector3 pos)
    {
        ParticleSystem particle = particles[(int)result];
        GameObject par = Instantiate(particle.gameObject, pos, Quaternion.identity);
        float totalDuration = particle.main.duration + particle.main.startLifetimeMultiplier;
        Destroy(par, totalDuration);
    }


}