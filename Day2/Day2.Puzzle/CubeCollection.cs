namespace Day2.Puzzle;

internal readonly record struct CubeCollection(int Green = 0, int Blue = 0, int Red = 0)
{
	public static CubeCollection operator +(CubeCollection c1, CubeCollection c2)
		=> new(c1.Green + c2.Green, c1.Blue + c2.Blue, c1.Red + c2.Red);

	public static CubeCollection AllGreen(int count) => new(Green: count);
	public static CubeCollection AllBlue(int count) => new(Blue: count);
	public static CubeCollection AllRed(int count) => new(Red: count);
}
