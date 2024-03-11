using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<Vector3> netPos = new NetworkVariable<Vector3>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    private NetworkVariable<Quaternion> netRot = new NetworkVariable<Quaternion>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);


    public override void OnNetworkSpawn() 
    {

    }
    public override void OnNetworkDespawn() 
    {

    }

    private void Update()
    {
        if (IsOwner)
        {
            netPos.Value = transform.position;
            netRot.Value = transform.rotation;
        }
        else
        {
            transform.position = netPos.Value;
            transform.rotation = netRot.Value;
        }
    }
}
