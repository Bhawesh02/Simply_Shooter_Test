
using System;
using System.Collections;
using UnityEngine;

public class PlayerController
{
    private Vector2 movementAmount;
    private PlayerView playerView;
    private PlayerModel playerModel;
    private float nextEnemyDetectionTime;
    private float nextEnemyShootTime;

    public PlayerController(PlayerView view)
    {
        playerView = view;
        playerModel = new();
        nextEnemyDetectionTime = Time.time;
        nextEnemyShootTime = Time.time;
    }

    public void SetMovementAmount(Vector2 movAmt)
    {
        movementAmount = movAmt;
    }

    public void MovePlayer()
    {
        if (movementAmount == Vector2.zero)
            return;
        Vector3 scaledMovement = playerView.NavMeshAgent.speed * Time.deltaTime * new Vector3(movementAmount.x, 0, movementAmount.y);
        if (playerModel.Enemy == null)
            playerView.transform.LookAt(playerView.transform.position + scaledMovement, Vector3.up);
        playerView.NavMeshAgent.Move(scaledMovement);
    }

    public void ChangeWeapon(WeaponScritableObject weapon)
    {
        if (playerModel.CurrentWeapon != null && weapon.WeaponType == playerModel.CurrentWeapon.WeaponType)
            return;
        playerModel.CurrentWeapon = weapon;
        playerModel.CurrentWeaponContainer?.SetActive(false);
        ShowWeapon(weapon.WeaponType);
    }

    private void ShowWeapon(WeaponTypes weaponType)
    {
        switch (weaponType)
        {
            case WeaponTypes.Pistol:
                playerModel.CurrentWeaponContainer = playerView.WeaponContainer.PistolContainer;
                break;
            case WeaponTypes.Shotgun:
                playerModel.CurrentWeaponContainer = playerView.WeaponContainer.ShotgunContainer;
                break;
            case WeaponTypes.MachineGun:
                playerModel.CurrentWeaponContainer = playerView.WeaponContainer.MachinegunContainer;
                break;
            case WeaponTypes.Launcher:
                playerModel.CurrentWeaponContainer = playerView.WeaponContainer.LauncherContainer;
                break;
        }
        playerModel.CurrentWeaponContainer.SetActive(true);
    }

    public void EnemyFightAI()
    {
        if (Time.time >= nextEnemyDetectionTime)
        {
            DetectEnemy();
            nextEnemyDetectionTime = Time.time + playerModel.EnemyDetectionDelay;
        }
        if (playerModel.Enemy == null)
            return;
        AimAtEnemy();
        if (Time.time >= nextEnemyShootTime)
        {
            ShootAtEnemy();
            nextEnemyShootTime = Time.time + (60f / playerModel.CurrentWeapon.FireRate) / 60f;
        }
    }



    private void DetectEnemy()
    {
        Collider[] enemyColliders = Physics.OverlapSphere(playerView.transform.position, playerModel.CurrentWeapon.AttackRange, playerView.EnemyLayer);
        if (enemyColliders.Length == 0)
        {
            playerModel.Enemy = null;
            return;
        }
        playerModel.Enemy = enemyColliders[0].GetComponentInParent<EnemyView>();
    }

    private void AimAtEnemy()
    {
        Vector3 distanceBetweenEnemyAndPlayer = playerModel.Enemy.transform.position - playerView.transform.position;
        float rotationY = Mathf.Atan2(distanceBetweenEnemyAndPlayer.x, distanceBetweenEnemyAndPlayer.z) * Mathf.Rad2Deg;
        playerView.transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
    }
    private void ShootAtEnemy()
    {
        ProjectileController projectile;
        if (playerModel.CurrentWeapon.ProjectileType == ProjectileType.Missile)
            projectile = ProjectileService.Instance.GetMissile();
        else
            projectile = ProjectileService.Instance.GetBullet();
        projectile.SetEnemtTransform(playerModel.Enemy.gameObject.transform);
        Transform spawnPoint = playerModel.CurrentWeaponContainer.transform.GetChild(1).transform;
        projectile.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        projectile.gameObject.SetActive(true);
        projectile.Fly();
    }
}
