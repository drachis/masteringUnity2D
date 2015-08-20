using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public float xMargin = 1.5f;
    public float yMargin = 1.5f;
    public float xSmooth = 1.5f;
    public float ySmooth = 1.5f;

    
    public Transform player;
    public GameObject background;

    private Vector2 maxXandY;
    private Vector2 minXandY;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player object not found");
        }
        var backgroundBounds = background.GetComponent<Renderer>().bounds;
        var camTopLeft = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0, 0));
        var camBotRight = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 1, 0));

        minXandY.x = backgroundBounds.min.x - camTopLeft.x;
        maxXandY.x = backgroundBounds.max.x - camBotRight.x;
    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        /*
         * An addition here for feel, 
         * char: >
         * margin: |
         * screen edge: [, ]
         * currently : [ |  >| ]
         * desired: [ |>  | ]
         * so that the player can see ahead in a desired direction.
         */
        if (CheckXMargin())
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        if (CheckYMargin())
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXandY.y);
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
