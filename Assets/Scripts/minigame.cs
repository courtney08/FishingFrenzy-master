using UnityEngine;

public class minigame : MonoBehaviour
{
 public RectTransform pointer;
    public RectTransform greenZone;
    public RectTransform redZoneTop;
    public RectTransform redZoneBottom;

    public float pointerSpeed = 500f;
    private bool movingUp = true;
    private bool isPlaying = false;

    public System.Action<bool> OnResult;

    void OnEnable()
    {
        isPlaying = true;
        ResetPointer();
        pointer.SetAsLastSibling(); // Makes sure pointer is on top
    }

    void Update()
    {
        if (!isPlaying) return;

        MovePointer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlaying = false;
            CheckResult();
        }
    }

    private void MovePointer()
    {
        float move = pointerSpeed * Time.deltaTime * (movingUp ? 1 : -1);
    pointer.anchoredPosition += new Vector2(0, move);

    // Get bounds from BarBackground's height
    float halfHeight = ((RectTransform)pointer.parent).rect.height / 2f;
    float pointerY = pointer.anchoredPosition.y;

    if (pointerY >= halfHeight)
    {
        pointer.anchoredPosition = new Vector2(0, halfHeight);
        movingUp = false;
    }
    else if (pointerY <= -halfHeight)
    {
        pointer.anchoredPosition = new Vector2(0, -halfHeight);
        movingUp = true;
    }
    }

    private void CheckResult()
    {
        if (IsPointerInside(greenZone))
        {
            OnResult?.Invoke(true);
        }
        else
        {
            OnResult?.Invoke(false);
        }
    }

    private bool IsPointerInside(RectTransform zone)
    {
        Vector3[] zoneCorners = new Vector3[4];
        zone.GetWorldCorners(zoneCorners);

        Vector3 pointerPos = pointer.position;
        return pointerPos.y >= zoneCorners[0].y && pointerPos.y <= zoneCorners[1].y;
    }

    private void ResetPointer()
    {
        pointer.anchoredPosition = Vector2.zero;
        movingUp = true;
    }
}