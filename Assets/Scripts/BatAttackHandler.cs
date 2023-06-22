using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class BatAttackHandler : MonoBehaviour
{
    public Animator batAnimator;
    public AnimationClip batAttackAnim;
    public XROrigin playerOrigin;

    private void OnTriggerEnter(Collider other)
    {
        // stop player movement 
        ActionBasedContinuousMoveProvider playermove = playerOrigin.GetComponentInChildren<ActionBasedContinuousMoveProvider>();
        ActionBasedSnapTurnProvider playerturn = playerOrigin.GetComponentInChildren<ActionBasedSnapTurnProvider>();
        TeleportationProvider playertele = playerOrigin.GetComponentInChildren<TeleportationProvider>();
        playermove.enabled = false;
        playerturn.enabled = false;
        playertele.enabled = false;
        // apply camera position to animation position
        // start cutscene
        batAnimator.SetInteger("attackStart", 1);
        // restart player movement
        playermove.enabled = true;
        playerturn.enabled = true;
        playertele.enabled = true;
    }
}
