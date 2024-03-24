using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _spawnPoint;

    private bool _input;

    public override void OnNetworkSpawn()
    {
        // if (!IsOwner) Destroy(this);
    }

    private void Update()
    {
        if (!IsOwner) return;
        _input = Input.GetKeyDown(KeyCode.Space);

        HandleShooting();
    }

    private void HandleShooting()
    {
        if (_input)
        {
            ShootRpc();
        }
    }

    [Rpc(SendTo.Server)]
    private void ShootRpc()
    {
        var instance = Instantiate(_projectile, _spawnPoint.position, transform.rotation);
        var instanceNetworkObj = instance.GetComponent<NetworkObject>();
        instanceNetworkObj.Spawn();
    }
}
