using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.Networking
{
    public class CustomSceneManager : MonoBehaviour
    {
        public static Dictionary<int, GameObject> m_DictScenes = new Dictionary<int, GameObject>();
        [SerializeField] private Transform m_scenes;

        private void Awake()
        {

            int i = 0;
            foreach (Transform scene in m_scenes)
            {
                m_DictScenes[i] = scene.gameObject;
                i++;
            }
        }

        private static void SetInactiveScenes()
        {
            foreach (GameObject scene in m_DictScenes.Values)
            {
                scene.SetActive(false);
            }
        }

        private static void SetActiveScene(int numberScene)
        {
            GameObject scene;
            if (m_DictScenes.TryGetValue(numberScene, out scene))
                scene.SetActive(true);
            else
                throw new System.Exception(string.Format("Key wasn't found " + numberScene + " Value: " + scene));
        }

        public static void ChangeScene(int numScene)
        {
            SetInactiveScenes();
            SetActiveScene(numScene);
        }
    }

}
