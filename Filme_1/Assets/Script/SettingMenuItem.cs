using UnityEngine;
using UnityEngine.UI;

public class SettingMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;

    PlusBtn plusBtn;
    int idx;

    Button btn;
    void Awake()
    {
        img = GetComponent<Image> ();
        trans = transform;

        plusBtn = transform.parent.GetComponent <PlusBtn> ();
        idx = trans.GetSiblingIndex() - 1;

        btn = GetComponent<Button> ();
        btn.onClick.AddListener(onItemClk);

    }

    void onItemClk()
    {
        plusBtn.OnBtnClick(idx);
    }

    void OnDestroy()
    {
        btn.onClick.RemoveListener(onItemClk);
    }
}
