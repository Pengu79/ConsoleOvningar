namespace SnowFlake2._0
{
    public interface IMovable
    {
        bool isMoving { get; set; }
        int OldX { get; set; }
        int OldY { get; set; }

        void MoveObject(string direction);
    }
}