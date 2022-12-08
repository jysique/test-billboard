using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestCameraDirection : MonoBehaviour
{
    [SerializeField] protected Facing _facing = Facing.Down;
	
	public virtual Facing Facing { get { return _facing; } }
	private void Awake()
    {
        
    }
    private void Update()
    {
        
    }
    private void LateUpdate()
    {
		
		float rX = transform.rotation.eulerAngles.z;
		float x = Mathf.Abs(rX);

		if(x < 22.5 || x > 337.5f)
        {
			_facing = Facing.Up;
		}else if (x < 67.5f)
        {
			_facing = Facing.UpLeft;
		}else if (x < 112.5f)
        {
			_facing = Facing.Left;
		}
		else if (x < 157.5f)
		{
			_facing = Facing.DownLeft;
		}else if(x < 202.5)
        {
			_facing = Facing.Down;
        }else if(x < 247.5)
        {
			_facing = Facing.DownRight;
		}
		else if (x < 292.5)
		{
			_facing = Facing.Right;
		}
		else if (x < 337.5)
		{
			_facing = Facing.UpRight;
		}
	}
}
