namespace DecoratePattern;

public abstract class BaseDecorator : IWomen
{
    protected IWomen women;
    public BaseDecorator(IWomen women)
    {
        this.women = women;
    }

    public virtual IWomen Show()
    {
        return women.Show();
    }
}