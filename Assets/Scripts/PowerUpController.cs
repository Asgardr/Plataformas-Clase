using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PowerUpController : MonoBehaviour
{
    private ThirdPersonCharacter character;
    private TrailRenderer trailRenderer;
    private IEnumerator corutine;

    private void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void ActivarPowerUp(float m_SuperJumpHeight, float m_duration)
    {
        corutine = PowerUpActive(m_SuperJumpHeight, m_duration);
        StartCoroutine(corutine);
    }

    IEnumerator PowerUpActive(float m_SuperJumpHeight, float m_duration)
    {
        character.SetJumpHeight(m_SuperJumpHeight);
        GUIManager.Instance.StartPowerUpTimer(m_duration);
        trailRenderer.enabled = true;

        yield return new WaitForSeconds(m_duration);

        character.RestoreJumpHeight();
        trailRenderer.enabled = false;
    }

    public void StopPowerUp()
    {
        StopCoroutine(corutine);
        GUIManager.Instance.StartPowerUpTimer(0f);
        character.RestoreJumpHeight();
        trailRenderer.enabled = false;
    }
}
