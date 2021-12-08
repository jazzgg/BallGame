public interface IPoolable 
{
    public bool IsActive { get; }

    public void Enable();
    public void Disable();
}
