using HutongGames.PlayMaker.Actions;
using MSCLoader;
using UnityEngine;

namespace MyUniversalUtils.ModLoader
{
    /// <summary>
    /// Takes care of loading assets from AssetBundles in a more user-friendly way, with multiple constructors for different loading methods and various functions to load specific asset types. Also includes convenient methods for instantiating prefabs directly from the bundle. 
    /// </summary>
    public class AssetExtensions
    {
        // Properties

        /// <summary>
        /// Bundle of given AssetExtensions isntance
        /// </summary>
        public AssetBundle Bundle { get; private set; }

        // Constructors

        /// <summary>
        /// Creates a new AssetExtensions instance. Note that the Bundles are NOT Unloaded to prevent beginner Porgrammers erros. If you need it unload you can always call the Unload method on the Bundle property of the AssetExtensions instance.
        /// </summary>
        /// <param name="bundle">Bundle to Set.</param>
        public AssetExtensions(AssetBundle bundle)
        {
            Bundle = bundle;
        }
        /// <summary>
        /// Creates a new AssetExtensions instance. Note that the Bundles are NOT Unloaded to prevent beginner Porgrammers erros. If you need it unload you can always call the Unload method on the Bundle property of the AssetExtensions instance.
        /// </summary>
        /// <param name="assetBundleResource">Resources.YourBundle</param>
        public AssetExtensions(byte[] assetBundleResource)
        {
            Bundle = GetBundle(assetBundleResource);
        }
        /// <summary>
        /// Creates a new AssetExtensions instance. Note that the Bundles are NOT Unloaded to prevent beginner Porgrammers erros. If you need it unload you can always call the Unload method on the Bundle property of the AssetExtensions instance.
        /// </summary>
        /// <param name="mod">Your Mod</param>
        /// <param name="assetBundleName">Name of the Bundle in given Mod Asset Folder</param>
        public AssetExtensions(Mod mod, string assetBundleName)
        {
            Bundle = GetBundle(mod, assetBundleName);
        }

        // Static Functions
        private static AssetBundle GetBundle(byte[] bundleFromResources)
        {
            if (bundleFromResources == null)
            {
                ModConsole.LogError("Asset bundle byte array cannot be null.");
                return null;
            }
            AssetBundle bundle = LoadAssets.LoadBundle(bundleFromResources);
            return bundle;
        }
        private static AssetBundle GetBundle(Mod mod, string bundleName)
        {
            if (mod == null)
            {
                ModConsole.LogError("Mod cannot be null when loading an asset bundle.");
                return null;
            }
            if (string.IsNullOrEmpty(bundleName))
            {
                ModConsole.LogError("Asset bundle name cannot be null or empty.");
                return null;
            }
            AssetBundle bundle = LoadAssets.LoadBundle(mod, bundleName);
            return bundle;
        }
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
        public Texture LoadTexture(string textureName)
        {
            return GetAsset<Texture>(textureName, Bundle);
        }
        /// <summary>
        /// Loads a GameObject from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public GameObject LoadPrefab(string prefabName)
        {
            return GetAsset<GameObject>(prefabName, Bundle);
        }
        /// <summary>
        /// Loads an AudioClip from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public AudioClip LoadAudioClip(string audioClipName)
        {
            return GetAsset<AudioClip>(audioClipName, Bundle);
        }
        /// <summary>
        /// Loads a Material from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public Material LoadMaterial(string materialName)
        {
            return GetAsset<Material>(materialName, Bundle);
        }
        /// <summary>
        /// Loads a Mesh from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public Mesh LoadMesh(string meshAssetName)
        {
            return GetAsset<Mesh>(meshAssetName, Bundle);
        }
        /// <summary>
        /// Loads a Shader from the AssetExtensions instance Bundle with the given name.
        /// </summary>
        public Shader LoadShader(string shaderName)
        {
            return GetAsset<Shader>(shaderName, Bundle);
        }

        // Multiple Loading Methods

        /// <summary>
        /// Loads Textures from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public Texture[] LoadTextures(params string[] textureNames)
        {
            Texture[] textures = new Texture[textureNames.Length];
            for (int i = 0; i < textureNames.Length; i++)
            {
                textures[i] = LoadTexture(textureNames[i]);
            }
            return textures;
        }
        /// <summary>
        /// Loads Prefabs from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public GameObject[] LoadPrefabs(params string[] prefabNames)
        {
            GameObject[] prefabs = new GameObject[prefabNames.Length];
            for (int i = 0; i < prefabNames.Length; i++)
            {
                prefabs[i] = LoadPrefab(prefabNames[i]);
            }
            return prefabs;
        }
        /// <summary>
        /// Loads Audio Clips from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public AudioClip[] LoadAudioClips(params string[] audioClipNames)
        {
            AudioClip[] audioClips = new AudioClip[audioClipNames.Length];
            for (int i = 0; i < audioClipNames.Length; i++)
            {
                audioClips[i] = LoadAudioClip(audioClipNames[i]);
            }
            return audioClips;
        }
        /// <summary>
        /// Loads Materials from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public Material[] LoadMaterials(params string[] materialNames)
        {
            Material[] materials = new Material[materialNames.Length];
            for (int i = 0; i < materialNames.Length; i++)
            {
                materials[i] = LoadMaterial(materialNames[i]);
            }
            return materials;
        }
        /// <summary>
        /// Loads Meshes from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public Mesh[] LoadMeshes(params string[] meshAssetNames)
        {
            Mesh[] meshes = new Mesh[meshAssetNames.Length];
            for (int i = 0; i < meshAssetNames.Length; i++)
            {
                meshes[i] = LoadMesh(meshAssetNames[i]);
            }
            return meshes;
        }
        /// <summary>
        /// Loads Shaders from the AssetExtensions instance Bundle with the given names.
        /// </summary>
        public Shader[] LoadShaders(params string[] shaderNames)
        {
            Shader[] shaders = new Shader[shaderNames.Length];
            for (int i = 0; i < shaderNames.Length; i++)
            {
                shaders[i] = LoadShader(shaderNames[i]);
            }
            return shaders;
        }

        // Instantiate and Other Funcs

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle by name.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle by name and assigns a custom name.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, string name)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            return obj;
        }


        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle at a specified local position.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="pos">Local position to set for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, Vector3 pos)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.transform.localPosition = pos;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle with a custom name at a specified local position.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <param name="pos">Local position to set for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, string name, Vector3 pos)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            obj.transform.localPosition = pos;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle at a specified position and rotation.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, Vector3 position, Vector3 rotation)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle with a custom name at a specified position and rotation.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, string name, Vector3 position, Vector3 rotation)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle at a specified position and rotation with a parent Transform.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <param name="parent">Parent Transform to assign to the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, Vector3 position, Vector3 rotation, Transform parent)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.transform.SetParent(parent);
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

        /// <summary>
        /// Instantiates a prefab from this instance's AssetBundle with a custom name at a specified position and rotation with a parent Transform.
        /// </summary>
        /// <param name="prefabName">The name of the prefab to instantiate.</param>
        /// <param name="name">The name to assign to the instantiated GameObject.</param>
        /// <param name="position">Local position for the instantiated GameObject.</param>
        /// <param name="rotation">Local rotation (Euler angles) for the instantiated GameObject.</param>
        /// <param name="parent">Parent Transform to assign to the instantiated GameObject.</param>
        /// <returns>The instantiated GameObject.</returns>
        public GameObject InstantiateFromPrefab(string prefabName, string name, Vector3 position, Vector3 rotation, Transform parent)
        {
            GameObject obj = LoadPrefab(prefabName);
            GameObject.Instantiate(obj);
            obj.name = name;
            obj.transform.SetParent(parent);
            obj.transform.localPosition = position;
            obj.transform.localEulerAngles = rotation;
            return obj;
        }

    }
}
