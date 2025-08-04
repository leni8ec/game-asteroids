using TMPro;
using UnityEngine;

namespace Asteroids.GUI.Test {
    public class TestTextMeshProSetValue : MonoBehaviour {
        public TextMeshProUGUI coords;
        public TextMeshProUGUI angle;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI laserCount;
        public TextMeshProUGUI laserRefillCountdown;
        public TextMeshProUGUI weapon1Countdown;
        public TextMeshProUGUI weapon2Countdown;

        private Transform target;

        private float speedValue;
        private float countdown1 = 5;
        private float countdown2 = 10;

        private void Update() {
            speedValue = Random.value;
            if (countdown1 > 0) countdown1 -= Time.deltaTime;
            if (countdown2 > 0) countdown2 -= Time.deltaTime;

            UpdateText();
        }

        private void UpdateText() {
            Vector3 position = target.position;
            Vector3 rotation = target.rotation.eulerAngles;

            // TestMethodFormattingText(position, rotation, speedValue);
            // TestMethodFormattingTextByTMP(position, rotation, speedValue);
            TestPropertyFormattingTest(position, rotation);
            // TestPropertyDummy();
            // TestMethodDummy();
        }


    #region TMP performance tests of the set text field values

        // 'text' property - doesn't update canvas if it's value not changed, when 'SetText' - will be update text on every call
        // Sources
        // - https://discussions.unity.com/t/textmesh-pro-text-vs-settext-setchararray-significant-performance-differences/921981/3
        // - https://discussions.unity.com/t/textmeshpro-update-gc-in-editor/892282

        // slowly, if called on every update method
        private void TestMethodFormattingText(Vector3 playerPosition, Vector3 playerRotation) {
            coords.SetText($"Coords: [ {playerPosition.x:F1} : {playerPosition.y:F1} ]");
            angle.SetText($"Angle: {playerRotation.z:F0}");
            speed.SetText($"Speed: {speedValue:N}");
            weapon1Countdown.SetText($"Weapon 1 countdown: {countdown1:0.00}");
            weapon2Countdown.SetText($"Weapon 2 countdown: {countdown2:0.00}");
        }

        // It's identical to a 'TestMethodFormattingText' (by comparing performance in unity profiler)
        private void TestMethodFormattingTextByTMP(Vector3 playerPosition, Vector3 playerRotation) {
            coords.SetText("Coords: [ {0:0.0} : {1:0.0} ]", playerPosition.x, playerPosition.y);
            angle.SetText("Angle: {0:0}", playerRotation.z);
            speed.SetText("Speed: {0:0.00}", speedValue);
            weapon1Countdown.SetText("Weapon 1 countdown: {0:0.00}", countdown1);
            weapon2Countdown.SetText("Weapon 2 countdown: {0:0.00}", countdown2);
        }

        // Fastest variant (does not update the text if it has not changed)
        private void TestPropertyFormattingTest(Vector3 playerPosition, Vector3 playerRotation) {
            coords.text = $"Coords: [ {playerPosition.x:F1} : {playerPosition.y:F1} ]";
            angle.text = $"Angle: {playerRotation.z:F0}";
            speed.text = $"Speed: {speedValue:N}";
            weapon1Countdown.text = $"Weapon 1 countdown: {countdown1:0.00}";
            weapon2Countdown.text = $"Weapon 2 countdown: {countdown2:0.00}";
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