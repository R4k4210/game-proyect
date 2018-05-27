using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VJHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image jsContainer;
    private Image joystick;
    private bool isactive = false;
    public Canvas canv;
    public GeneralManager gameManager;

    private Vector2 PosicionInicial,posicion;
    private float Distancia = 1f;

    public Vector3 InputDirection;

    void Start()
    {
        canv.renderMode = RenderMode.ScreenSpaceCamera;
        canv.worldCamera = gameManager.camara.GetComponent<Camera>();
        jsContainer = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>(); //this command is used because there is only one child in hierarchy
        InputDirection = Vector3.zero;
        PosicionInicial = jsContainer.rectTransform.position;
    }

    private void Update()
    {
        posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("rect joystick = "+PosicionInicial+" / rect stick = "+joystick.rectTransform.position+" / joystick pos = "+jsContainer.transform.position + " / stick pos = "+joystick.transform.position);
        //Debug.Log(Input.mousePosition +" / "+ Camera.main.ScreenToWorldPoint(Input.mousePosition));
        
        Debug.Log("distancia x = " + Mathf.Abs(jsContainer.transform.position.x - posicion.x) + " / distancia y = " + Mathf.Abs(jsContainer.transform.position.y - posicion.y));
    }

    private Vector2 joystickPosition()
    {
        Vector2 retorno = new Vector2();



        return retorno;
    }

    public void OnDrag(PointerEventData ped)
    {
        //Debug.Log("a32424234sd");
        Vector2 position = Vector2.zero;

        //To get InputDirection
        RectTransformUtility.ScreenPointToLocalPointInRectangle
                (jsContainer.rectTransform,
                ped.position,
                ped.pressEventCamera,
                out position);

        //Debug.Log("position = "+position);
        position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
        position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

        float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
        float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

        InputDirection = new Vector3(x, y, 0);
        //Debug.Log(InputDirection + " / "+ InputDirection.normalized);
        InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

        //to define the area in which joystick can move around
        
        joystick.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3), InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);
        if (!isactive)
        {
            joystick.rectTransform.position = GetComponent<RectTransform>().position;
            isactive = true;
        }

    }

    public void OnPointerDown(PointerEventData ped)
    {
        //Debug.Log("asd");
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        //Debug.Log("asderer");
        InputDirection = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        isactive = false;   
    }
}