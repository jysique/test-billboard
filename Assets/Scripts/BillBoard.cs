using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
	LookAtPlayer,
	LookAtDirection
}
public enum Facing
{
	Up,
	UpRight,
	Right,
	DownRight,
	Down,
	DownLeft,
	Left,
	UpLeft
}

public class BillBoard : MonoBehaviour
{
    private SpriteRenderer sprite;
    private TestCameraDirection cameraDirection;
	public State state = State.LookAtPlayer;
	[SerializeField]private Facing _facingDirection = Facing.Down;
	
	public List<Sprite> sprites = new List<Sprite>();
	
	private void Start()
    {
		Init();

	}
	public void Init()
    {
		sprite = GetComponent<SpriteRenderer>();
		cameraDirection = GameManager.instance.PlayerController.TestCameraDirection;
		//sprite.flipX = true;
	}
    private void Update()
    {
		Facing direction = 0;
        switch (state)
        {
            case State.LookAtDirection:
				
				int offset = _facingDirection - cameraDirection.Facing;

				if (offset < 0)
				{
					offset += 8;
				}
				
				direction = (Facing)offset;
				
				switch (direction)
				{
					case Facing.DownLeft:
						direction = Facing.DownRight;
						sprite.flipX = true;
						break;
					case Facing.Left:
						direction = Facing.Right;
						sprite.flipX = true;
						break;
					case Facing.UpLeft:
						direction = Facing.UpRight;
						sprite.flipX = true;
						break;
					default:
						sprite.flipX = false;
						break;
				}
				break;
            case State.LookAtPlayer:
				direction = Facing.Down;
				break;
        }

		transform.LookAt(GameManager.instance.PlayerController.transform.position, -Vector3.forward);

		sprite.sprite = sprites[(int)direction];
	}
}
