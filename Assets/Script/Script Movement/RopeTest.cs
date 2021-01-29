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
    public Spawner spawner;
    public float NombreMortIndication;
    void Start()
    {

        spawner=GameObject.FindObjectOfType<Spawner>();
        SonChoisi= GetComponent<AudioSource>();
        _lineRenderer = GetComponent<LineRenderer>();

    }

    void Update()
    {
        NombreMortIndication=Spawner.NombreMonstreMort;
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
            Spawner.NombreMonstreMort+=1;
             ObjetTouche.GetComponent<CircleCollider2D>().enabled=false;
            ObjetTouche.GetComponentInChildren<ParticleSystem>().Play();
             SonChoisi.clip=SonLien[Random.Range(0,2)];
        	SonChoisi.PlayOneShot(SonChoisi.clip);
            screenShake.enabled=true;
             ObjetTouche.GetComponent<InstantiPieces>().SpawnPieces();
            screenShake.shakeDuration=0.25f;
              ObjetTouche.GetComponent<SpriteRenderer>().enabled=false;
            Destroy(hit.collider.gameObject,1);
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
    }

}
