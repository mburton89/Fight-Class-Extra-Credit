using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPreview : MonoBehaviour
{
    [SerializeField] private Image _characterPose;
    [SerializeField] private TextMeshProUGUI _characterName;

    public List<Sprite> currentIdleSprites;

    public float idleFrameDuration;

    private void Start()
    {
        PlayIdleAnimation();
        UpdateCharacterPose(0);
    }

    public void UpdateCharacterPose(int index)
    {
        //_characterPose.sprite = DataReferenceManager.Instance.characterPoses[index];
        _characterName.SetText(DataReferenceManager.Instance.characterNames[index]);
        currentIdleSprites = DataReferenceManager.Instance.idleSprites[index];
    }

    public void PlayIdleAnimation()
    {
        StartCoroutine(IdleAnimation());
    }

    private IEnumerator IdleAnimation()
    {
        _characterPose.sprite = currentIdleSprites[0];
        yield return new WaitForSeconds(idleFrameDuration);
        _characterPose.sprite = currentIdleSprites[1];
        yield return new WaitForSeconds(idleFrameDuration);
        _characterPose.sprite = currentIdleSprites[2];
        yield return new WaitForSeconds(idleFrameDuration);
        PlayIdleAnimation();
    }
}
