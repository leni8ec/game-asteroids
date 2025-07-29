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

            // TestMethodFormattingText(playerPosition, playerRotation, playerSpeed);
            // TestMethodFormattingTextByTMP(playerPosition, playerRotation, playerSpeed);
            TestPropertyFormattingTest(playerPosition, playerRotation, playerSpeed);
            // TestPropertyDummy();
            // TestMethodDummy();
        }


    #region TMP performance tests of the set text field values

        // 'text' property - doesn't update canvas if it's value not changed, when 'SetText' - will be update text on every call
        // Sources
        // - https://discussions.unity.com/t/textmesh-pro-text-vs-settext-setchararray-significant-performance-differences/921981/3
        // - https://discussions.unity.com/t/textmeshpro-update-gc-in-editor/892282

        // slowly, if called on every update method
        private void TestMethodFormattingText(Vector3 playerPosition, Vector3 playerRotation, float playerSpeed) {
            coords.SetText($"Coords: [ {playerPosition.x:F1} : {playerPosition.y:F1} ]");
            angle.SetText($"Angle: {playerRotation.z:F0}");
            speed.SetText($"Speed: {playerSpeed:N}");
            laserCount.SetText($"Laser Count: {weapon.laserShotsCount}");
            laserRefillCountdown.SetText($"Laser Countdown: {weapon.laserRefillCountdown:0.00}");
            weapon1Countdown.SetText($"Weapon 1 countdown: {weapon.fire1Countdown:0.00}");
            weapon2Countdown.SetText($"Weapon 2 countdown: {weapon.fire2Countdown:0.00}");
        }

        // It's identical to a 'TestMethodFormattingText' (by comparing performance in unity profiler)
        private void TestMethodFormattingTextByTMP(Vector3 playerPosition, Vector3 playerRotation, float playerSpeed) {
            coords.SetText("Coords: [ {0:0.0} : {1:0.0} ]", playerPosition.x, playerPosition.y);
            angle.SetText("Angle: {0:0}", playerRotation.z);
            speed.SetText("Speed: {0:0.00}", playerSpeed);
            laserCount.SetText("Laser Count: {0}", weapon.laserShotsCount);
            laserRefillCountdown.SetText("Laser Countdown: {0:0.00}", weapon.laserRefillCountdown);
            weapon1Countdown.SetText("Weapon 1 countdown: {0:0.00}", weapon.fire1Countdown);
            weapon2Countdown.SetText("Weapon 2 countdown: {0:0.00}", weapon.fire2Countdown);
        }

        // Fastest variant (does not update the text if it has not changed)
        private void TestPropertyFormattingTest(Vector3 playerPosition, Vector3 playerRotation, float playerSpeed) {
            coords.text = $"Coords: [ {playerPosition.x:F1} : {playerPosition.y:F1} ]";
            angle.text = $"Angle: {playerRotation.z:F0}";
            speed.text = $"Speed: {playerSpeed:N}";
            laserCount.text = $"Laser Count: {weapon.laserShotsCount}";
            laserRefillCountdown.text = $"Laser Countdown: {weapon.laserRefillCountdown:0.00}";
            weapon1Countdown.text = $"Weapon 1 countdown: {weapon.fire1Countdown:0.00}";
            weapon2Countdown.text = $"Weapon 2 countdown: {weapon.fire2Countdown:0.00}";
        }

        // TMP fast variant (Property)
        // (canvas is not updated if text value has not been changing)
        private void TestPropertyDummy() {
            angle.text = "text";
            speed.text = "text";
            laserCount.text = "text";
            laserRefillCountdown.text = "text";
            weapon1Countdown.text = "text";
            weapon2Countdown.text = "text";
        }

        // TMP slow variant (Method)
        // (canvas will be updated every time, it doesn't matter if the text value has been changed or not)
        private void TestMethodDummy() {
            angle.SetText("text");
            speed.SetText("text");
            laserCount.SetText("text");
            laserRefillCountdown.SetText("text");
            weapon1Countdown.SetText("text");
            weapon2Countdown.SetText("text");
        }

    #endregion


    }
}