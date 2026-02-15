using HutongGames.PlayMaker.Actions;
using MSCLoader;
using UnityEngine;

namespace MyUniversalUtils.ModLoader
{
    /// <summary>
    /// Takes care of loading assets from AssetBundles in a more user-friendly way, with multiple constructors for different loading methods and various functions to load specific asset types. Also includes convenient methods for instantiating prefabs directly from the bundle. 
    /// </summary>
    public static class AssetExtensions
    {
        // Helper
        private static T GetAsset<T>(string assetName, AssetBundle assetBundle) where T : UnityEngine.Object
        {
            if (string.IsNullOrEmpty(assetName))
            {
                ModConsole.LogError("Asset name cannot be null or empty.");
                return null;
            }
            T asset = assetBundle.LoadAsset<T>(assetName);
            if (asset == null)
            {
                ModConsole.LogError("Failed to load asset: " + assetName + " from bundle.");
            }
            return asset;
        }

        // Single Loading Methods

        /// <summary>
        /// Loads a Texture from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public static Texture LoadTexture(this AssetBundle bundle, string textureName)
        {
            return GetAsset<Texture>(textureName, bundle);
        }
        /// <summary>
        /// Loads a GameObject from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public static GameObject LoadPrefab(this AssetBundle bundle, string prefabName)
        {
            return GetAsset<GameObject>(prefabName, bundle);
        }
        /// <summary>
        /// Loads an AudioClip from the AssetExtensions instance bundle with the given name.
        /// </summary>
        public static AudioClip LoadAudioClip(this AssetBundle bundle, string audioClipName)
        {
            return GetAsset<AudioClip>(audioClipName, bundle);
        }
        /// <summary>
        /// Loads a Material from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public static Material LoadMaterial(this AssetBundle bundle, string materialName)
        {
            return GetAsset<Material>(materialName, bundle);
        }
        /// <summary>
        /// Loads a Mesh from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public static Mesh LoadMesh(this AssetBundle bundle, string meshAssetName)
        {
            return GetAsset<Mesh>(meshAssetName, bundle);
        }
        /// <summary>
        /// Loads a Shader from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public static Shader LoadShader(this AssetBundle bundle, string shaderName)
        {
            return GetAsset<Shader>(shaderName, bundle);
        }

        // Multiple Loading Methods

        /// <summary>
        /// Loads Textures from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public static Texture[] LoadTextures(this AssetBundle bundle, params string[] textureNames)
        {
            Texture[] textures = new Texture[textureNames.Length];
            for (int i = 0; i < textureNames.Length; i++)
            {
                textures[i] = LoadTexture(bundle, textureNames[i]);
            }
            return textures;
        }
        /// <summary>
        /// Loads Prefabs from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public static GameObject[] LoadPrefabs(this AssetBundle bundle, params string[] prefabNames)
        {
            GameObject[] prefabs = new GameObject[prefabNames.Length];
            for (int i = 0; i < prefabNames.Length; i++)
            {
                prefabs[i] = LoadPrefab(bundle, prefabNames[i]);
            }
            return prefabs;
        }
        /// <summary>
        /// Loads Audio Clips from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public static AudioClip[] LoadAudioClips(this AssetBundle bundle, params string[] audioClipNames)
        {
            AudioClip[] audioClips = new AudioClip[audioClipNames.Length];
            for (int i = 0; i < audioClipNames.Length; i++)
            {
                audioClips[i] = LoadAudioClip(bundle, audioClipNames[i]);
            }
            return audioClips;
        }
        /// <summary>
        /// Loads Materials from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public static Material[] LoadMaterials(this AssetBundle bundle, params string[] materialNames)
        {
            Material[] materials = new Material[materialNames.Length];
            for (int i = 0; i < materialNames.Length; i++)
            {
                materials[i] = LoadMaterial(bundle, materialNames[i]);
            }
            return materials;
        }
        /// <summary>
        /// Loads Meshes from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public static Mesh[] LoadMeshes(this AssetBundle bundle, params string[] meshAssetNames)
        {
            Mesh[] meshes = new Mesh[meshAssetNames.Length];
            for (int i = 0; i < meshAssetNames.Length; i++)
            {
                meshes[i] = LoadMesh(bundle, meshAssetNames[i]);
            }
            return meshes;
        }
        /// <summary>
        /// Loads Shaders from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public static Shader[] LoadShaders(this AssetBundle bundle, params string[] shaderNames)
        {
            Shader[] shaders = new Shader[shaderNames.Length];
            for (int i = 0; i < shaderNames.Length; i++)
            {
                shaders[i] = LoadShader(bundle, shaderNames[i]);
            }
            return shaders;
        }

        // Instantiate and Other Funcs

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle by name.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle by name and assigns a custom name.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, string name)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            return obj;
        }


        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle at a specified local position.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="pos">Local position to set for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, Vector3 pos)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.transform.localPosition = pos;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle with a custom name at a specified local position.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <param name="pos">Local position to set for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, string name, Vector3 pos)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            obj.transform.localPosition = pos;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle at a specified position and rotation.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, Vector3 position, Vector3 rotation)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle with a custom name at a specified position and rotation.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, string name, Vector3 position, Vector3 rotation)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle at a specified position and rotation with a parent Transform.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <param name="parent">Parent Transform to assign to the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, Vector3 position, Vector3 rotation, Transform parent)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.transform.SetParent(parent);
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle with a custom name at a specified position and rotation with a parent Transform.
        /// </summary>
        /// <param name="bundle">Given bundle Instance.</param>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <param name="parent">Parent Transform to assign to the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public static GameObject InstantiateFromPrefab(this AssetBundle bundle, string prefabName, string name, Vector3 position, Vector3 rotation, Transform parent)
        {
            GameObject obj = LoadPrefab(bundle, prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            obj.transform.SetParent(parent);
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

    }
}
