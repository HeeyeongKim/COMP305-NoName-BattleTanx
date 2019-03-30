using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyExplosionSound; // explosion sound for enemy
    public static AudioClip woodExplosionSound; // explosion sound for wood
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemyExplosionSound = Resources.Load<AudioClip>("EnemyExplosion");
        woodExplosionSound = Resources.Load<AudioClip>("WoodExplosion");
        audioSrc = GetComponent<AudioSource>();
    }

    // Sounds
    public static void playSound(){
        audioSrc.PlayOneShot(enemyExplosionSound);
    }

  /*   public static void PlayWoodExplosion(){
        audioSrc.PlayOneShot(woodExplosionSound);
    } */
}
