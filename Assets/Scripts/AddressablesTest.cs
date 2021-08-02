using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class AddressablesTest : MonoBehaviour
{
    public Canvas mainCanvas;

    public AssetReference ar;

    // private List<GameObject> m_PrefabLst;
    private GameObject m_Window;

    // Start is called before the first frame update
    void Start()
    {

        // var _ = LoadPrefab();

        // m_PrefabLst = new List<GameObject>();

        ar.LoadAssetAsync<GameObject>().Completed += handle =>
        {
            Debug.Log(ar.Asset.name);

            var prefab = handle.Result;
            // m_PrefabLst.Add(prefab);

            var go = Instantiate(prefab, mainCanvas.transform);
            go.transform.localPosition = Vector3.zero;

            m_Window = go;

            m_Window.GetComponentInChildren<Button>().onClick.AddListener((() =>
            {
                if (null == m_Window) return;

                Addressables.ReleaseInstance(m_Window);
            }));
        };


    }

    private async Task LoadPrefab()
    {
        // var instance = await Addressables.InstantiateAsync(prefabName, mainCanvas.transform).Task;
        // instance.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}