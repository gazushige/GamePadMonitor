using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//***Important***
//New Input System Required.Import it from the package manager.
public class PadMonitorManager : MonoBehaviour
{
    [SerializeField]
    private Color _padColor;
    [SerializeField]
    private Color _releasedColor;
    [SerializeField]
    private Color _onPressColor;
    [SerializeField]
    private Vector3 _scale = new Vector3(1f, 1f, 1f);
    /// <summary>
    /// Initial Position
    /// </summary>
    private Vector3 LStickPosition;
    /// <summary>
    /// Initial Position
    /// </summary>
    private Vector3 RStickPosition;
    private Transform LSTransform;
    private Transform RSTransform;
    private ButtonImages images = new ButtonImages();
    private GamePadStatus status = new GamePadStatus();
    private bool isConnected => (Gamepad.current != null);
    /// <summary>
    /// Stick UI Moving Range
    /// </summary>
    private const float stickRange = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //If no gamepad connected,this will be disabled.
        if (!isConnected)
        {
            this.enabled = false;
            return;
        }
        this.gameObject.transform.localScale = _scale;
        this.gameObject.GetComponent<Image>().color = _padColor;
        var childrenTransform = this.gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in childrenTransform)
        {
            if (!child.gameObject.GetComponent<Image>() || this.gameObject == child.gameObject) continue;
            child.gameObject.GetComponent<Image>().color = _releasedColor;
        }
        Init();
    }
    private void Init()
    {
        LSTransform = GameObject.Find("LStick").transform;
        RSTransform = GameObject.Find("RStick").transform;
        LStickPosition = LSTransform.localPosition;
        RStickPosition = RSTransform.localPosition;
        images.LStick = GameObject.Find("LStick").GetComponent<Image>();
        images.RStick = GameObject.Find("RStick").GetComponent<Image>();
        images.North = GameObject.Find("NorthButton").GetComponent<Image>();
        images.East = GameObject.Find("EastButton").GetComponent<Image>();
        images.South = GameObject.Find("SouthButton").GetComponent<Image>();
        images.West = GameObject.Find("WestButton").GetComponent<Image>();
        images.Up = GameObject.Find("UpButton").GetComponent<Image>();
        images.Right = GameObject.Find("RightButton").GetComponent<Image>();
        images.Down = GameObject.Find("DownButton").GetComponent<Image>();
        images.Left = GameObject.Find("LeftButton").GetComponent<Image>();
        images.L1 = GameObject.Find("L1Trigger").GetComponent<Image>();
        images.L2 = GameObject.Find("L2Trigger").GetComponent<Image>();
        images.R1 = GameObject.Find("R1Trigger").GetComponent<Image>();
        images.R2 = GameObject.Find("R2Trigger").GetComponent<Image>();
        images.Start = GameObject.Find("Start").GetComponent<Image>();
        images.Select = GameObject.Find("Select").GetComponent<Image>();
    }
    private void Update()
    {
        if (status.LStick == Vector2.zero) images.LStick.color = _releasedColor;
        else images.LStick.color = _onPressColor;
        if (status.RStick == Vector2.zero) images.RStick.color = _releasedColor;
        else images.RStick.color = _onPressColor;
        LSTransform.localPosition = new Vector3(status.LStick.x, status.LStick.y, 0) * stickRange + LStickPosition;
        RSTransform.localPosition = new Vector3(status.RStick.x, status.RStick.y, 0) * stickRange + RStickPosition;
        if (status.North) images.North.color = _onPressColor;
        else images.North.color = _releasedColor;
        if (status.East) images.East.color = _onPressColor;
        else images.East.color = _releasedColor;
        if (status.South) images.South.color = _onPressColor;
        else images.South.color = _releasedColor;
        if (status.West) images.West.color = _onPressColor;
        else images.West.color = _releasedColor;
        if (status.Up) images.Up.color = _onPressColor;
        else images.Up.color = _releasedColor;
        if (status.Right) images.Right.color = _onPressColor;
        else images.Right.color = _releasedColor;
        if (status.Down) images.Down.color = _onPressColor;
        else images.Down.color = _releasedColor;
        if (status.Left) images.Left.color = _onPressColor;
        else images.Left.color = _releasedColor;
        if (status.L1) images.L1.color = _onPressColor;
        else images.L1.color = _releasedColor;
        if (status.L2) images.L2.color = _onPressColor;
        else images.L2.color = _releasedColor;
        if (status.R1) images.R1.color = _onPressColor;
        else images.R1.color = _releasedColor;
        if (status.R2) images.R2.color = _onPressColor;
        else images.R2.color = _releasedColor;
        if (status.Start) images.Start.color = _onPressColor;
        else images.Start.color = _releasedColor;
        if (status.Select) images.Select.color = _onPressColor;
        else images.Select.color = _releasedColor;
    }
    /// <summary>
    /// Image Components
    /// </summary>
    private class ButtonImages
    {
        public Image LStick;
        public Image RStick;
        public Image North;
        public Image East;
        public Image South;
        public Image West;
        public Image Up;
        public Image Right;
        public Image Down;
        public Image Left;
        public Image L1;
        public Image L2;
        public Image R1;
        public Image R2;
        public Image Start;
        public Image Select;
    }
    /// <summary>
    /// Status Getter
    /// </summary>
    private class GamePadStatus
    {
        public Vector2 LStick => Gamepad.current.leftStick.ReadValue();
        public Vector2 RStick => Gamepad.current.rightStick.ReadValue();
        public bool North => Gamepad.current.buttonNorth.IsPressed();
        public bool East => Gamepad.current.buttonEast.IsPressed();
        public bool South => Gamepad.current.buttonSouth.IsPressed();
        public bool West => Gamepad.current.buttonWest.IsPressed();
        public bool Up => Gamepad.current.dpad.up.IsPressed();
        public bool Right => Gamepad.current.dpad.right.IsPressed();
        public bool Down => Gamepad.current.dpad.down.IsPressed();
        public bool Left => Gamepad.current.dpad.left.IsPressed();
        public bool L1 => Gamepad.current.leftShoulder.IsPressed();
        public bool L2 => Gamepad.current.leftTrigger.IsPressed();
        public bool R1 => Gamepad.current.rightShoulder.IsPressed();
        public bool R2 => Gamepad.current.rightTrigger.IsPressed();
        public bool Start => Gamepad.current.startButton.IsPressed();
        public bool Select => Gamepad.current.selectButton.IsPressed();

    }
}