using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTest : MonoBehaviour
{
    [SerializeField] private GameObject player1, player2;
    private LineRenderer _lineRenderer;
    [SerializeField] private Transform center;
    [SerializeField] private LayerMask castMask;
    private float radius = 2;

    public List<AudioClip>SonLien;
    public AudioSource SonChoisi;
    public ScreenShake screenShake;
    private GameObject ObjetTouche;
    void Start()
    {
        SonChoisi= GetComponent<AudioSource>();
        _lineRenderer = GetComponent<LineRenderer>();

    }

    void Update()
    {
        p2Radius();
        castEnemy();
        center.position = (player1.transform.position + player2.transform.position) / 2;
        _lineRenderer.SetPosition(0, player1.transform.position);
        _lineRenderer.SetPosition(1, player2.transform.position);
    }

    void p2Radius()
    {
        Vector3 centerPosition = center.localPosition;
        float distance1 = Vector3.Distance(player1.transform.position, centerPosition);
        float distance2 = Vector3.Distance(player2.transform.position, centerPosition);

        if (distance1 > radius)
        {
            Vector3 fromOriginToObject = player1.transform.position - centerPosition;
            fromOriginToObject *= radius / distance1;
            player1.transform.position = centerPosition + fromOriginToObject;
        }
        if (distance2 > radius)
        {
            Vector3 fromOriginToObject = player2.transform.position - centerPosition;
            fromOriginToObject *= radius / distance2;
            player2.transform.position = centerPosition + fromOriginToObject;
        }
    }

    void castEnemy()
    {
        RaycastHit2D hit;
        hit = Physics2D.Linecast(player1.transform.position, player2.transform.position, castMask);
        if(hit.collider != null)
        {
            ObjetTouche=hit.collider.gameObject;
            ObjetTouche.GetComponentInChildren<ParticleSystem>().Play();
            //Destroy(hit.collider.gameObject);
            
             SonChoisi.clip=SonLien[Random.Range(0,2)];
        	SonChoisi.PlayOneShot(SonChoisi.clip);
            screenShake.enabled=true;
             ObjetTouche.GetComponent<InstantiPieces>().SpawnPieces();
            screenShake.shakeDuration=0.25f;
            StartCoroutine(coroutineA());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center.position, radius);
    }

    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(0.25f);
       screenShake.enabled=false;
       ObjetTouche.GetComponent<CircleCollider2D>().enabled=false;
    }

}
