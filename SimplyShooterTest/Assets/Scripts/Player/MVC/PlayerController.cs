
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
    private float hypeStartTime;
    public PlayerController(PlayerView view, PlayerScriptableObject playerData)
    {
        playerView = view;
        playerModel = new(playerData);
        nextEnemyDetectionTime = Time.time;
        nextEnemyShootTime = Time.time;
    }
    public void RefreshPlayerData(PlayerScriptableObject playerData)
    {
        playerModel.SetPlayerData(playerData);
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
        if (playerModel.Enemies.Count == 0)
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
        playerModel.CurrentFireRate = weapon.FireRate;
        if (playerModel.InHypeMode)
        {
            playerModel.CurrentFireRate *= playerModel.HypeModeFireRateMultiplier;
        }
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
            DetectEnemies();
            nextEnemyDetectionTime = Time.time + playerModel.EnemyDetectionDelay;
        }
        if (playerModel.Enemies.Count == 0)
            return;
        GetNearestEnemy();
        AimAtNearestEnemy();
        if (Time.time >= nextEnemyShootTime)
        {
            ShootAtEnemy();
            nextEnemyShootTime = Time.time + (60f / playerModel.CurrentFireRate) / 60f;
        }
    }



    private void DetectEnemies()
    {
        Collider[] enemyColliders = Physics.OverlapSphere(playerView.transform.position, playerModel.CurrentWeapon.AttackRange, playerView.EnemyLayer);
        playerModel.Enemies.Clear();
        if (enemyColliders.Length == 0)
        {
            return;
        }
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            playerModel.Enemies.Add(enemyColliders[i].GetComponent<EnemyView>());
        }
    }
    private void GetNearestEnemy()
    {
        float minDistance = 9999f;
        float enemyDistance;
        for (int i = 0; i < playerModel.Enemies.Count; i++)
        {
            enemyDistance = Vector3.Distance(playerModel.Enemies[i].transform.position, playerView.transform.position);
            if (enemyDistance < minDistance)
            {
                minDistance = enemyDistance;
                playerModel.NearestEnemy = playerModel.Enemies[i];
            }
        }
    }
    private void AimAtNearestEnemy()
    {
        Vector3 distanceBetweenEnemyAndPlayer = playerModel.NearestEnemy.transform.position - playerView.transform.position;
        float rotationY = Mathf.Atan2(distanceBetweenEnemyAndPlayer.x, distanceBetweenEnemyAndPlayer.z) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
        playerView.transform.rotation = Quaternion.RotateTowards(playerView.transform.rotation, targetRotation, Time.deltaTime * playerModel.AutoAimRotationSpeed);
    }



    private void ShootAtEnemy()
    {
        ProjectileController projectile;
        if (playerModel.CurrentWeapon.ProjectileType == ProjectileType.Missile)
            projectile = ProjectileService.Instance.GetMissile();
        else
            projectile = ProjectileService.Instance.GetBullet();
        projectile.SetEnemtTransform(playerModel.NearestEnemy.gameObject.transform);
        projectile.SetDamage(playerModel.CurrentWeapon.Damage);
        Transform spawnPoint = playerModel.CurrentWeaponContainer.transform.GetChild(1).transform;
        projectile.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        projectile.gameObject.SetActive(true);
        projectile.Fly();
    }

    public void EmenyKilled(EnemyView enemy)
    {
        playerModel.Enemies.Remove(enemy);
        nextEnemyDetectionTime = Time.time;
        if (playerModel.NumberOfEnemiesKilledSinceLastHypeCharge < playerModel.NumOfEnemiesToKillToChargeHype)
        {
            playerModel.NumberOfEnemiesKilledSinceLastHypeCharge++;
        }
    }

    public IEnumerator HypeMode()
    {
        StartHype();
        yield return new WaitForSeconds(playerModel.HypeModeDuration);
        ResetHype();
    }

    private void StartHype()
    {
        EventService.Instance.InvokeHypeModeStarted();
        playerModel.InHypeMode = true;
        playerModel.CurrentFireRate *= playerModel.HypeModeFireRateMultiplier;
        hypeStartTime = Time.time;
    }

    private void ResetHype()
    {
        EventService.Instance.InvokeHypeModeEnded();
        playerModel.InHypeMode = false;
        playerModel.NumberOfEnemiesKilledSinceLastHypeCharge = 0;
        playerModel.CurrentFireRate /= playerModel.HypeModeFireRateMultiplier;
    }

    public void IncreaseCoinCollected(CoinPickupController controller)
    {
        playerModel.NumOfCoinsColleted++;
    }
    public bool GetInHypeMode()
    {
        return playerModel.InHypeMode;
    }
    public int GetNumberOfCoinsCollected()
    {
        return playerModel.NumOfCoinsColleted;
    }

    public float GetHowMuchHypeIsCharged()
    {
        return (float)playerModel.NumberOfEnemiesKilledSinceLastHypeCharge / (float)playerModel.NumOfEnemiesToKillToChargeHype;
    }

    public float GetHowMuchHypeIsLeft()
    {
        return (((hypeStartTime + playerModel.HypeModeDuration) - Time.time) / playerModel.HypeModeDuration);
    }

    public void PlayerWon()
    {
        playerView.enabled = false;
    }
}
