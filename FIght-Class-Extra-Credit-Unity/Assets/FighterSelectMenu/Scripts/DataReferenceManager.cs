using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReferenceManager : MonoBehaviour
{
    public static DataReferenceManager Instance;

    public List<string> characterNames;
    public List<Sprite> characterThumbnails;
    public List<Sprite> characterPoses;
    public List<Sprite> levelImages;

    public List<List<Sprite>> idleSprites;
    [SerializeField] private List<Sprite> alecIdle;
    [SerializeField] private List<Sprite> danielIdle;
    [SerializeField] private List<Sprite> dannyIdle;
    [SerializeField] private List<Sprite> evanIdle;
    [SerializeField] private List<Sprite> joshIdle;
    [SerializeField] private List<Sprite> markIdle;
    [SerializeField] private List<Sprite> robertIdle;
    [SerializeField] private List<Sprite> zachIdle;
    [SerializeField] private List<Sprite> mattIdle;

    public List<AudioClip> characterConfirmVO;

    public List<GameObject> fighterPrefabs;

    public int p1Index;
    public int p2Index;
    public int levelIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        idleSprites = new List<List<Sprite>>();

        idleSprites.Add(alecIdle);
        idleSprites.Add(danielIdle);
        idleSprites.Add(dannyIdle);
        idleSprites.Add(evanIdle);
        idleSprites.Add(joshIdle);
        idleSprites.Add(markIdle);
        idleSprites.Add(robertIdle);
        idleSprites.Add(zachIdle);
        idleSprites.Add(mattIdle);
    }
}
