using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Transform startTf, endTf;
    public Image draggableImage;

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 할 때, 이미지의 위치를 바꿔주기
        var transformLocalPosition = draggableImage.transform.localPosition;
        transformLocalPosition += new Vector3(eventData.delta.x, 0, 0);
        
        transformLocalPosition.x = Mathf.Clamp(transformLocalPosition.x, endTf.transform.localPosition.x,
            startTf.transform.localPosition.x);
        draggableImage.transform.localPosition = transformLocalPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        draggableImage.transform.DOKill();

        // 절반 이상 넘어 갔냐?
        if (0 >= draggableImage.transform.localPosition.x -
            (startTf.transform.localPosition.x - endTf.transform.localPosition.x) / 2)
        {
            draggableImage.transform.DOLocalMoveX(endTf.localPosition.x, 0.25f);
            draggableImage.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            draggableImage.transform.DOLocalMoveX(startTf.localPosition.x, 0.25f);
            draggableImage.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
