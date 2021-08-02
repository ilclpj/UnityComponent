using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : ScrollRect
{
    [HideInInspector]
    public RectTransform background;

    [HideInInspector]
    public RectTransform stick;

    [HideInInspector]
    public RectTransform arrow;

    /// <summary>
    /// 摇杆操作中
    /// </summary>
    public bool stickRunning;

    /// <summary>
    /// 摇杆方向
    /// </summary>
    public Vector2 stickDirection;

    /// <summary>
    /// 摇杆可移动半径
    /// </summary>
    private float m_StickRadius;

    /// <summary>
    /// 箭头半径
    /// </summary>
    private float m_ArrowRadius;

    protected override void Awake()
    {
        SetBackground();
    }

    public void SetBackground()
    {
        if (background == null) return;

        viewport = background;

        var width = viewport.sizeDelta.x;
        m_StickRadius = (width - stick.sizeDelta.x) * 0.5f;
        m_ArrowRadius = width * 0.5f - 2;

        arrow.gameObject.SetActive(false);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        var contentPosition = content.anchoredPosition;
        var position = contentPosition.normalized;

        if (contentPosition.magnitude > m_StickRadius)
        {
            SetContentAnchoredPosition(position * m_StickRadius);
        }

        arrow.anchoredPosition = position * m_ArrowRadius;

        var angle = Vector2.Angle(position, Vector2.right);
        arrow.localEulerAngles = new Vector3(0, 0, position.y > 0 ? angle : -angle);

        arrow.gameObject.SetActive(true);

        stickRunning = true;
        stickDirection = position;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        arrow.gameObject.SetActive(false);
        arrow.anchoredPosition = Vector2.right * m_ArrowRadius;
        arrow.localEulerAngles = Vector3.zero;

        stickRunning = false;
        stickDirection = Vector2.zero;
    }
}