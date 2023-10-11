using UnityEngine;
using UnityEngine.AI;

public class Pedestrians_nav : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] GameObject PATH;

    private Transform[] PathPoints;

    public int index = 0;
    public float minDistance = 1f; // Adjust this value as needed

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PathPoints.Length; i++)
        {
            PathPoints[i] = PATH.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        roam();
    }

    private void roam()
    {
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
        {
            index = (index + 1) % PathPoints.Length;
        }

        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("Vertical", !agent.isStopped ? 1 : 0);
    }
}
