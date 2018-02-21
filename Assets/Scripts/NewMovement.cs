using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class NewMovement : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D poly;
    private Rigidbody2D rig;
    private SpriteRenderer spr;

    #region Variables
    [Header("Insert Axis Names")]
    [SerializeField] string HorizontalAxis;
    [SerializeField] string VerticalAxis;
    [SerializeField] string AbilityAxis;
    [Range(1, 2)]
    [SerializeField] int PlayerIndex;
    [Space]
    [Header("Insert Player Variables")]
    public float Speed;
    public float JumpHeight;
    [SerializeField] private string WalkAnim;
    private float cache_speed;
    public bool Jumping;
    
#endregion

    void Start()
    {
        cache_speed = Speed;
        rig = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw(HorizontalAxis) != 0)
        {
            Move(Input.GetAxisRaw(HorizontalAxis), Speed);
            anim.SetBool(WalkAnim, true);
        }
        else { anim.SetBool(WalkAnim, false); }

        if (Input.GetAxisRaw(VerticalAxis) != 0 && !Jumping) { Jump(JumpHeight); }

        if (Input.GetAxisRaw(AbilityAxis) != 0)
        {
            CauseAbility(true, PlayerIndex);
        }
        else if (Input.GetAxisRaw(AbilityAxis) == 0)
        {
            CauseAbility(false, PlayerIndex);
        }
    }

    public void Move(float dir, float speed)
    {
        rig.velocity = new Vector2(speed * dir, rig.velocity.y);
    }

    public void Jump(float speed)
    {
        Jumping = true;
        rig.AddForce(transform.up * (speed * 45));
    }

    public void CauseAbility(bool effect, int playerCount)
    {
        if (playerCount == 1)
        {
            int child = transform.childCount;
            for (int i = 0; i < child; i++)
            {
                if (transform.GetChild(i).name == "Shield")
                {
                    transform.GetChild(i).gameObject.SetActive(effect);
                }
            }
        }

        if (playerCount == 2)
        {
            if (effect == true)
            {
                GameObject Player1 = GameObject.Find("Player");
                Vector2 targetpos = Player1.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetpos, 7 * Time.deltaTime);
            }

        }

    }
}
