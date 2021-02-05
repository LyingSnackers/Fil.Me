using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlusBtn : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Plus Button rotation")]
    [SerializeField] float rotDuration;
    [SerializeField] Ease rotEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collpaseFadeDuration;

    Button plusBtn;
    SettingMenuItem[] menuItems;
    bool isExpand = false;

    Vector2 plusBtnPos;
    int itemCnt;

    void Start()
    {
        itemCnt = transform.childCount - 1;
        menuItems = new SettingMenuItem[itemCnt];
        for(int i = 0; i < itemCnt; i++){
            menuItems[i] = transform.GetChild (i+1).GetComponent <SettingMenuItem> ();
        }

        plusBtn = transform.GetChild (0).GetComponent <Button> ();
        plusBtn.onClick.AddListener(toggleItem);
        plusBtn.transform.SetAsLastSibling();
        plusBtnPos = plusBtn.transform.position;

        //Reset all
        resetPos();
    }

    void resetPos()
    {
        for(int i = 0; i < itemCnt; i++){
            menuItems[i].trans.position = plusBtnPos;
        }
    }

    void toggleItem()
    {
        isExpand = !isExpand;

        if(isExpand){ //List expanded
            for(int i = 0; i < itemCnt; i++){
                //Original
                //menuItems[i].trans.position = plusBtnPos + spacing*(i+1);

                menuItems[i].trans.DOMove(plusBtnPos + spacing*(i+1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        else{ //List closed
            for(int i = 0; i < itemCnt; i++){
                menuItems[i].trans.DOMove(plusBtnPos, collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(1f, collpaseFadeDuration);
            }
        }
        plusBtn.transform.DORotate(Vector3.forward*180f, rotDuration).From(Vector3.zero).SetEase(rotEase);
    }

    public void OnBtnClick(int idx){
        switch(idx){
            case 0: //setting
                Debug.Log("Setting");
                break;
            case 1: //share
                Debug.Log("sharing");
                break;
            case 2: //background
                Debug.Log("background");
                break;
            case 3: //Rope
                Debug.Log("Rope");
                break;
            case 4: //Image
                Debug.Log("Image");
                break;
        }
    }
    void OnDestroy(){
        plusBtn.onClick.RemoveListener(toggleItem);
    }
}
