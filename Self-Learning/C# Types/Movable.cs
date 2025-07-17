namespace PublicSpace.Moveable;

public interface IMoveble
{
    void Move(in short stepX, in short stepY);
    void Info();
}