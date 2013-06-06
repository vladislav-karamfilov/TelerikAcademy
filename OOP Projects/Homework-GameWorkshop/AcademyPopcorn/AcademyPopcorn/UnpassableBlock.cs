namespace AcademyPopcorn
{
    // Task 8: Implementation of UpassableBlock class
    public class UnpassableBlock : IndestructibleBlock
    {
        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0,0] = ']';
        }
    }
}
