using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BulletSpawner : NetworkBehaviour
{
    public Rigidbody bullet;
    private float bulletSpeed = 20f;

    [ServerRpc]
    public void FireServerRpc() {
        Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.velocity = transform.forward * bulletSpeed;
        newBullet.gameObject.GetComponent<NetworkObject>().Spawn();
        Destroy(newBullet.gameObject, 3);
    }
}
