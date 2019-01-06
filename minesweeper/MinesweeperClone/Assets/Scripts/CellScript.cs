
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour {

    public AudioClip flagCell;
    public AudioClip unFlagCell;
    public AudioClip flipCellSound;
    private AudioSource source;
    public GameObject grid;
    public List<GameObject> neighbors;
    private SpriteRenderer m_SpriteRenderer;
    public Sprite flag;
    public Sprite start;
    public Sprite blank;
    public Sprite skull;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    private bool flagged = false;
    private bool uncovered = false;
    private int cellIndex;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        grid = GameObject.Find("Grid");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        cellIndex = grid.GetComponent<GridGenerator>().map[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)];
    }

    public void FlipCell()
    {
        if (uncovered == false)
        {
            source.PlayOneShot(flipCellSound);
            if (cellIndex == 0)
            {
                uncovered = true;
                m_SpriteRenderer.sprite = blank;
                foreach (GameObject n in neighbors)
                {
                    n.SendMessage("FlipCell");   
                }
            }
            if (cellIndex == 1)
            {
                m_SpriteRenderer.sprite = one;
            }
            if (cellIndex == 2)
            {
                m_SpriteRenderer.sprite = two;
            }
            if (cellIndex == 3)
            {
                m_SpriteRenderer.sprite = three;
            }
            if (cellIndex == 4)
            {
                m_SpriteRenderer.sprite = four;
            }
            if (cellIndex == 5)
            {
                m_SpriteRenderer.sprite = five;
            }
            if (cellIndex == 6)
            {
                m_SpriteRenderer.sprite = six;
            }
            if (cellIndex == 7)
            {
                m_SpriteRenderer.sprite = seven;
            }
            if (cellIndex == 8)
            {
                m_SpriteRenderer.sprite = eight;
            }
            if (cellIndex == 9)
            {
                m_SpriteRenderer.sprite = skull;
                grid.SendMessage("GameLost");
            }
            uncovered = true;
            grid.GetComponent<GridGenerator>().boardState[Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)] = 9;
        }  
    }

    private void OnMouseExit()
    {
        m_SpriteRenderer.color = Color.white;
    }

    private void OnMouseOver()
    {
        m_SpriteRenderer.color = Color.blue;
        if (Input.GetButtonDown("Fire1") && grid.GetComponent<GridGenerator>().gameOver == false)
        {
            FlipCell();
        }
        if (Input.GetButtonDown("Fire2") && uncovered == false && grid.GetComponent<GridGenerator>().gameOver == false)
        {
            if (flagged == false)
            {
                source.PlayOneShot(flagCell);
                m_SpriteRenderer.sprite = flag;
                flagged = true;
            }
            else if (flagged == true)
            {
                source.PlayOneShot(unFlagCell);
                m_SpriteRenderer.sprite = start;
                flagged = false;
            }
        }
    }

    public void GameLost()
    {
        if (cellIndex == 9)
        {
            m_SpriteRenderer.sprite = skull;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        neighbors.Add(collision.gameObject);
    }
}
