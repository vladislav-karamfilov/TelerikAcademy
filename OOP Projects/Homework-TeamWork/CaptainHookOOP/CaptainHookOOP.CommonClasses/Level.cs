using System.Collections.Generic;

namespace CaptainHookOOP.CommonClasses
{
    internal abstract class Level
    {
        public char[,] LevelGrid { get; private set; }
        protected List<StaticObject> StaticObjects { get; private set; }
        protected List<MovingObject> MovingObjects { get; private set; }

        public Level()
        {
            this.StaticObjects = new List<StaticObject>();
            this.MovingObjects = new List<MovingObject>();
        }

        public void AddObject(GameObjects newObject)
        {
            if (newObject is StaticObject)
            {
                this.StaticObjects.Add(newObject as StaticObject);
            }
            else
            {
                this.MovingObjects.Add(newObject as MovingObject);
            }
        }

        public void PrintMovingObjects()
        {
            foreach (MovingObject movingObject in this.MovingObjects)
            {
                movingObject.PrintOnConsole();
            }
        }

        public void PrintStaticObjects()
        {
            foreach (StaticObject staticObject in this.StaticObjects)
            {
                staticObject.PrintOnConsole();
            }
        }

        public virtual void Load(int width, int height)
        {
            this.LevelGrid = new char[height, width];

            foreach (StaticObject staticObject in this.StaticObjects)
            {
                int startRow = staticObject.TopLeft.Row;
                int endRow = startRow + staticObject.Image.GetLength(0);

                int startCol = staticObject.TopLeft.Column;
                int endCol = startCol + staticObject.Image.GetLength(1);

                int currentRow = 0;
                int currentCol = 0;

                for (int row = startRow; row < endRow; row++, currentRow++, currentCol = 0)
                {
                    for (int col = startCol; col < endCol; col++, currentCol++)
                    {
                        this.LevelGrid[row, col] = staticObject.Image[currentRow, currentCol];
                    }
                }
            }
        }

        public void RemoveMovingObjects()
        {
            foreach (MovingObject movingObject in this.MovingObjects)
            {
                movingObject.RemoveFromConsole();
            }
        }
    }
}
