using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Базовый класс каширующий ссылки
/// </summary>
/// 
public abstract class Baseobject : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform goTransform;
    private GameObject goInstance;
    private string goname;

    private Rigidbody goRigidbody;

    private Material goMaterial;
    private Color goColor;
    private Animator goAnimator;

    private bool isViviable;

    protected Material GoMaterial { get => goMaterial; set => goMaterial = value; }
    protected Rigidbody GoRigidbody { get => goRigidbody; set => goRigidbody = value; }
    protected Transform GoTransform { get => goTransform; set => goTransform = value; }
    protected GameObject GoInstance { get => goInstance; set => goInstance = value; }
    protected string GoName { get => goname; set => goname = value; }
    protected Color GoColor { get => goColor; set => goColor = value; }
    protected Animator GoAnimator { get => goAnimator; set => goAnimator = value; }
    protected bool IsViviable { get => isViviable; set => isViviable = value; }

    protected virtual void Awake()
    {
        GoTransform = transform;
        GoName = name;
        GoInstance = gameObject;

        if(GetComponent<Animator>())
        {
            GoAnimator = GetComponent<Animator>();
        }
        else
        {
            Debug.Log(" NO ANIMATOR" + name);
        }
        if (GetComponent<Rigidbody>())
        {
            GoRigidbody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.Log(" NO Rigidbody" + name);
        }

        if(GetComponent<Renderer>())
        {

        }
    }
    void Start()
    {
        GoMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
