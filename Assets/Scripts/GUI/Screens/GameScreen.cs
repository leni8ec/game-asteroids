using Asteroids.Core.Actors.Player;
using Asteroids.Core.World.Entities.State;
using Asteroids.Core.World.Score;
using Asteroids.Core.World.Weapon;
using Asteroids.GUI.Base;
using TMPro;
using UnityEngine;

namespace Asteroids.GUI.Screens {
    // todo-later: add
    // - active enemies counts
    // - enemy spawn countdowns

    // todo-consider: optimize text formatting (to don't update text on every frame)
    // - may-be use a reactive properties (with presenter)?
    // - or use a 'ViewModel' with binders?
    public class GameScreen : GuiMono {
        public TextMeshProUGUI points;
        public TextMeshProUGUI coords;
        public TextMeshProUGUI angle;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI laserCount;
        public TextMeshProUGUI laserRefillCountdown;
        public TextMeshProUGUI weapon1Countdown;
        public TextMeshProUGUI weapon2Countdown;

        private EntitiesState entities;
        private ScoreState score;
        private WeaponState weapon;

        private void Start() {
            entities = GetState<EntitiesState>();
            score = GetState<ScoreState>();
            weapon = GetState<WeaponState>();

            score.Points.Changed += SetScore;
        }

        private void OnEnable() {
            SetScore(0);
        }

        private void SetScore(int value) {
            points.SetText($"Score: {value}");
        }

        private void Update() {
            Player player = entities.Player;
            if (player == null) return; // if player doesn't initialize

            UpdateText(player);
        }

        private void UpdateText(Player player) {
            Vector3 playerPosition = player.Position;
            Vector3 playerRotation = player.Rotation;
            float playerSpeed = player.State.speed;

            coords.SetText($"Coords: [ {playerPosition.x:F1} : {playerPosition.y:F1} ]");
            angle.SetText($"Angle: {playerRotation.z:F0}");
            speed.SetText($"Speed: {playerSpeed:N}");
            laserCount.SetText($"Laser Count: {weapon.laserShotsCount}");
            laserRefillCountdown.SetText($"Laser Countdown: {weapon.laserRefillCountdown:0.00}");
            weapon1Countdown.SetText($"Weapon 1 countdown: {weapon.fire1Countdown:0.00}");
            weapon2Countdown.SetText($"Weapon 2 countdown: {weapon.fire2Countdown:0.00}");
        }



    }
}