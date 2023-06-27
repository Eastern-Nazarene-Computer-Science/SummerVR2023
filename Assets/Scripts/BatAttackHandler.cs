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
    public GameObject BAT;
    public GameObject mainCam;
    public AudioClip scream;

    public void BatTriggerEnter(Collider other)
    {
        // stop player movement 
        ActionBasedSnapTurnProvider playerturnb = playerOrigin.GetComponentInChildren<ActionBasedSnapTurnProvider>();
        ActionBasedContinuousTurnProvider playerturna = playerOrigin.GetComponentInChildren<ActionBasedContinuousTurnProvider>();
        ActionBasedContinuousMoveProvider playermove = playerOrigin.GetComponentInChildren<ActionBasedContinuousMoveProvider>();
        TeleportationProvider playertele = playerOrigin.GetComponentInChildren<TeleportationProvider>();
        if (playerturna)
        {
           playerturna.enabled = false;
        } else if (playerturnb)
        {
            playerturnb.enabled=false;
        }
        playermove.enabled = false;
        playertele.enabled = false;
        // apply camera position to animation position
        BAT.transform.SetParent(mainCam.transform);
        BAT.transform.localPosition = new Vector3(-0.35f, -9.38f, 1f);
        BAT.transform.rotation = new Quaternion(0, 45, 0, 1);
        // start cutscene
        batAnimator.SetBool("attackStart", true);
        AudioSource batscream = BAT.GetComponent<AudioSource>();
        batscream.PlayOneShot(scream);
    }

    public void RestartAfterAttack()
    {
        Debug.Log("restartafterattakc");
        ActionBasedSnapTurnProvider playerturnb = playerOrigin.GetComponentInChildren<ActionBasedSnapTurnProvider>();
        ActionBasedContinuousTurnProvider playerturna = playerOrigin.GetComponentInChildren<ActionBasedContinuousTurnProvider>();
        ActionBasedContinuousMoveProvider playermove = playerOrigin.GetComponentInChildren<ActionBasedContinuousMoveProvider>();
        TeleportationProvider playertele = playerOrigin.GetComponentInChildren<TeleportationProvider>();
        // restart player movement
        BAT.transform.SetParent(null);
        BAT.transform.position = Vector3.zero;
        playermove.enabled = true;
        if (playerturna)
        {
            playerturna.enabled = true;
        }
        else if (playerturnb)
        {
            playerturnb.enabled = true;
        }
        playertele.enabled = true;
    }
}
