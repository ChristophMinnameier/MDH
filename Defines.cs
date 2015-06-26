
public enum EDirection
{
	left,
	right,
	up,
	down
}

public enum Test
{
	left,
	right,
	up,
	down
}

public static class Foo
{
	public static EDirection GetLeft(EDirection _Direction) {
		switch (_Direction) {
		case EDirection.left:
			return EDirection.down;
		case EDirection.right:
			return EDirection.up;
		case EDirection.up:
			return EDirection.left;
		case EDirection.down:
			return EDirection.right;
		}
		return EDirection.right;
	}
}