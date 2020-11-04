using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightSceneController : MonoBehaviour
{
    public SpriteRenderer bg;

    [HideInInspector] public GameObject p1FighterAnimation;
    [HideInInspector] public GameObject p2FighterAnimation;

    public CharacterController2D p1CharacterController;
    public CharacterController2D p2CharacterController;

    public Vector3 fighterPosition = new Vector3();

    void Start()
    {
        bg.sprite = DataReferenceManager.Instance.levelImages[DataReferenceManager.Instance.levelIndex];

        p1FighterAnimation = Instantiate(DataReferenceManager.Instance.fighterPrefabs[DataReferenceManager.Instance.p1Index] as GameObject);
        p1FighterAnimation.transform.localPosition = new Vector3(-fighterPosition.x, fighterPosition.y, 0);
        HealthManager.Instance.p1Thumbnail.sprite = DataReferenceManager.Instance.characterThumbnails[DataReferenceManager.Instance.p1Index];
        p1FighterAnimation.GetComponent<FighterAnimationController>().EstablishP1Controls();
        p1FighterAnimation.transform.SetParent(p1CharacterController.transform);
        p1FighterAnimation.transform.localPosition = Vector3.zero;
        KOManager.Instance.p1 = p1FighterAnimation.GetComponent<FighterAnimationController>();

        p2FighterAnimation = Instantiate(DataReferenceManager.Instance.fighterPrefabs[DataReferenceManager.Instance.p2Index] as GameObject);
        p2FighterAnimation.transform.localPosition = new Vector3(fighterPosition.x, fighterPosition.y, 0);
        p2FighterAnimation.transform.localScale = new Vector3(-p2FighterAnimation.transform.localScale.x, p2FighterAnimation.transform.localScale.y, 0);
        HealthManager.Instance.p2Thumbnail.sprite = DataReferenceManager.Instance.characterThumbnails[DataReferenceManager.Instance.p2Index];
        p2FighterAnimation.GetComponent<FighterAnimationController>().EstablishP2Controls();
        p2FighterAnimation.transform.SetParent(p2CharacterController.transform);
        p2FighterAnimation.transform.localPosition = Vector3.zero;
        KOManager.Instance.p2 = p2FighterAnimation.GetComponent<FighterAnimationController>();

        MusicManager.Instance.SelectTrack(DataReferenceManager.Instance.levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
    }
}
