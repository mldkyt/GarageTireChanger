using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GarageTireChanger
{
    [BepInPlugin("me.mldchan.garagetirechanger", "Garage Tire Changer", "1.0")]
    public class GarageTireChanger : BaseUnityPlugin
    {
        private ConfigEntry<bool> enabled;

        private void Awake()
        {
            enabled = Config.Bind("General", "Enabled", true, "Enable the mod");

            SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        }

        private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log($"Scene loaded: \"{arg0.name}\"({arg0.buildIndex})");
            if (arg0.buildIndex != 2) return;
            if (!enabled.Value) return;
            var go = GameObject.Find("RaceTrackIsland").transform.GetChild(11).GetChild(10).gameObject;
            var parent = GameObject.Find("Home").transform.GetChild(3);
            var cloned = Instantiate(go, parent, true);
            cloned.name = "TireChanger_Manual";
            cloned.transform.localPosition = new Vector3(4.42f, 0.112f, 5.714f);
            cloned.transform.localRotation = Quaternion.Euler(0, 25.77f, 0);
        }
    }
}