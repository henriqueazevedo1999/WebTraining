namespace BusinessLogicalLayer;

abstract public class BaseValidator<T>
{
    //TODO: mover fluent validation do BLL para cá

    protected abstract void Normatize(T item);
    protected abstract void ReNormatize(T item);
}
