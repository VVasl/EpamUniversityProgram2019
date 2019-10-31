namespace StyleCopShapes
{
    public interface IShapes<T>
        where T : class
    {
        T ShapeOne { get; set; }

        T ShapeTwo { get; set; }

        T FindIntersectionOfShapes();

        bool DoShapesOverlap();
    }
}
