using UnityEngine;

public class PlayerControllerON : IPlayerControllerState
{

   
    private readonly GameObject player;

    private readonly float playerForwardSpeed = 10f;
    private readonly float sensetivity = 600f;

    private  float touchStartPosition = 0;
    private  float touchDistanse = 0;
    private readonly float bounds = 2.5f;

    public PlayerControllerON( GameObject curentPlayer) {

        player = curentPlayer;
       
    }
     
    public void Update()
    {
        SetTouchDistanse();
        MovePlayer();
       
    }

    void SetTouchDistanse()
    {
        Touch[] touches = Input.touches;
        if (touches.Length > 0)
        {

            if (touches[0].phase == TouchPhase.Began)
            {
                touchStartPosition = touches[0].position.x;
            }

            touchDistanse = touches[0].position.x - touchStartPosition;

        }
        else
        {
            touchDistanse = 0;
        }
    }

    void MovePlayer()
    {
       player. gameObject.transform.Translate(Vector3.forward * playerForwardSpeed * Time.deltaTime);

        float x =player. gameObject.transform.position.x + (touchDistanse / sensetivity);


        x = Mathf.Clamp(x, -bounds, bounds);
        player.gameObject.transform.position = new Vector3(x,player.gameObject. transform.position.y, player.gameObject.transform.position.z);



    }
}
