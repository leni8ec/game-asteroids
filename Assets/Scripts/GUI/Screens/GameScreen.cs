using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Players.Common;
using Asteroids.Core.World.Players.Weapons;
using Asteroids.Core.World.Score;
using Asteroids.Framework.Reactive;
using Asteroids.GUI.Base;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Asteroids.GUI.Screens {
    // todo-later: add
    // - active enemies counts
    // - enemy spawn countdowns
    public class GameScreen : UpdateableView {
        public TextMeshProUGUI points;
        public TextMeshProUGUI coords;
        public TextMeshProUGUI angle;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI laserCount;
        public TextMeshProUGUI laserRefillCountdown;
        public TextMeshProUGUI weapon1Countdown;
        public TextMeshProUGUI weapon2Countdown;


        public void SetScore(int value) => points.SetText($"Score: {value}");

        public void SetPlayerPosition(Vector3 value) => coords.SetText($"Coords: [ {value.x:F1} : {value.y:F1} ]");

        public void SetPlayerAngle(float value) => angle.SetText($"Angle: {value:F0}");

        public void SetPlayerSpeed(float value) => speed.SetText($"Speed: {value:N}");

        public void SetLaserCount(int value) => laserCount.text = $"Laser Count: {value}";

        public void SetLaserRefillCountdown(float value) => laserRefillCountdown.text = $"Laser Countdown: {value:0.00}";

        public void SetWeapon1Countdown(float value) => weapon1Countdown.text = $"Weapon 1 countdown: {value:0.00}";

        public void SetWeapon2Countdown(float value) => weapon2Countdown.text = $"Weapon 2 countdown: {value:0.00}";

    }

    [UsedImplicitly]
    internal class GameScreenPresenter : UpdateablePresenter<GameScreen> {

        private PlayersState players;
        private ScoreState score;
        private WeaponState weapon;

        private readonly ReactiveProperty<Vector3> playerPosition = new();
        private readonly ReactiveProperty<float> playerRotation = new();
        private readonly ReactiveProperty<float> playerSpeed = new();
        private readonly ReactiveProperty<float> laserRefillCountdown = new();
        private readonly ReactiveProperty<float> weapon1Countdown = new();
        private readonly ReactiveProperty<float> weapon2Countdown = new();

        public override void Construct() {
            players = GetState<PlayersState>();
            score = GetState<ScoreState>();
            weapon = GetState<WeaponState>();

            Subscribe(score.Points, View.SetScore);
            Subscribe(weapon.LaserShotsCount, View.SetLaserCount);

            Subscribe(playerPosition, View.SetPlayerPosition);
            Subscribe(playerRotation, View.SetPlayerAngle);
            Subscribe(playerSpeed, View.SetPlayerSpeed);
            Subscribe(laserRefillCountdown, View.SetLaserRefillCountdown);
            Subscribe(weapon1Countdown, View.SetWeapon1Countdown);
            Subscribe(weapon2Countdown, View.SetWeapon2Countdown);
        }

        protected override void OnEnableView() { }

        protected override void OnDisableView() { }

        protected override void OnUpdateView() {
            Player player = players.Active;
            if (player != null) {
                playerPosition.Value = player.Position;
                playerRotation.Value = player.Rotation;
                playerSpeed.Value = player.State.speed;
            }
            laserRefillCountdown.Value = weapon.LaserRefillCountdown;
            weapon1Countdown.Value = weapon.Fire1Countdown;
            weapon2Countdown.Value = weapon.Fire2Countdown;
        }

    }
}