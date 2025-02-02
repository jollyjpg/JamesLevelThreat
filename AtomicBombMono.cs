using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JamesLevelThreat;
using SimulationChamber;
using UnityEngine;
using Photon.Pun;

public class AtomicBombMono : MonoBehaviour
{
    public Player player;
    public Gun gun;

    // A list of guns created for this mono saved here.
    // Ideally you'll make a pool of guns for your mod to use.
    public SimulatedGun[] savedGuns = new SimulatedGun[2];

    public static GameObject _stopRecursionObj = null;

    public static GameObject StopRecursionObj
    {
        get
        {
            if (_stopRecursionObj == null)
            {
                _stopRecursionObj = new GameObject("A_StopRecursion", typeof(StopRecursion));
                DontDestroyOnLoad(_stopRecursionObj);
            }
            return _stopRecursionObj;
        }
    }

    public static ObjectsToSpawn[] StopRecursionSpawn
    {
        get
        {
            return new ObjectsToSpawn[] { new ObjectsToSpawn() { AddToProjectile = StopRecursionObj } };
        }
    }

    public void Start()
    {
        // Get Player
        this.player = this.GetComponentInParent<Player>();
        // Get Gun
        this.gun = this.player.data.weaponHandler.gun;
        // Hook up our action.
        this.gun.ShootPojectileAction += this.OnShootProjectileAction;

        // Checks to see if we have a saved gun already, if not, we make one.
        if (savedGuns[0] == null)
        {
            // We spawn a new object since this allows us manipulate the gun object's position without messing with the player's gameobjest.
            savedGuns[0] = new GameObject("X-Gun").AddComponent<SimulatedGun>();
        }

        // Checks to see if we have a second saved gun already, if not, we make one.
        if (savedGuns[1] == null)
        {
            savedGuns[1] = new GameObject("Y-Gun").AddComponent<SimulatedGun>();
        }
    }

    public void OnShootProjectileAction(GameObject obj)
    {
        // If the bullet has the StopRecursion component in it somewhere, we don't want to trigger.
        if (obj.GetComponentsInChildren<StopRecursion>().Length > 0)
        {
            return;
        }

        /*************************************************************************
        **************************************************************************
        *** Here's where we sync our guns so that people see the same effect when
        *** the guns are shot.
        **************************************************************************
        *************************************************************************/

        // We get our first gun that we made earlier
        // We're going to be using this as our gun for mirroring across the y-axis
        SimulatedGun xGun = savedGuns[0];

        // We copy over our gun stats, including actions, so that it's pretty much a copy of our gun.
        // Note, the methods for copying actions actually create separate instances of those actions
        xGun.numberOfProjectiles = 1;
        xGun.bursts = 0;
        xGun.spread = 0f;
        xGun.evenSpread = 0f;
        xGun.damage = 100;

        // Since we created a separate instance of our shootprojectile action, we can safely remove this action
        // to avoid our simulated gun from triggering it as well.
        //
        // If we had simply done `xGun.ShootPojectileAction = this.gun.ShootPojectileAction;` this would have also
        // removed the action from `this.gun.ShootPojectileAction`.
        xGun.ShootPojectileAction -= this.OnShootProjectileAction;

        // We only want to fire 1 bullet per bullet, since we're mirroring our attacks.
        xGun.objectsToSpawn = xGun.objectsToSpawn.Concat(StopRecursionSpawn).ToArray();

        // Our second gun is used to mirror about the y-axis
        // We use this gun since we want to have different values on our y than our x.
        SimulatedGun yGun = savedGuns[1];

        // Copy actions like before
        yGun.numberOfProjectiles = 1;
        yGun.bursts = 0;
        yGun.spread = 0f;
        yGun.evenSpread = 0f;
        yGun.damage = 100;

        yGun.objectsToSpawn = yGun.objectsToSpawn.Concat(StopRecursionSpawn).ToArray();

        /*************************************************************************
        **************************************************************************
        *** We check to see if the player who's shooting is that player, otherwise
        *** we'll end up firing a simulation gun for each player in the game.
        **************************************************************************
        *************************************************************************/
        if (!(player.data.view.IsMine || PhotonNetwork.OfflineMode))
        {
            return;
        }

        // Fires our gun that's mirrored across the y-axis, so we invert our x position and shoot angle.
        xGun.SimulatedAttack(this.player.playerID, new Vector3(obj.transform.position.x * -1f, obj.transform.position.y, 0), new Vector3(player.data.input.aimDirection.x * -1f, player.data.input.aimDirection.y, 0), 1f, 1);
        // Fires our gun that's mirrored across the x axis, inverting our y position and shoot angle.
        yGun.SimulatedAttack(this.player.playerID, new Vector3(obj.transform.position.x, obj.transform.position.y * -1f, 0), new Vector3(player.data.input.aimDirection.x, player.data.input.aimDirection.y * -1f, 0), 1f, 1);
        // Fires our gun that's mirrored across the x-axis, inverting our x and y position and shoot angle.
        yGun.SimulatedAttack(this.player.playerID, new Vector3(obj.transform.position.x * -1f, obj.transform.position.y * -1f, 0), new Vector3(player.data.input.aimDirection.x * -1f, player.data.input.aimDirection.y * -1f, 0), 1f, 1);
    }

    public void OnDestroy()
    {
        // Remove our action when the mono is removed
        gun.ShootPojectileAction -= OnShootProjectileAction;

        UnityEngine.GameObject.Destroy(savedGuns[0]);
        UnityEngine.GameObject.Destroy(savedGuns[1]);
    }
}
