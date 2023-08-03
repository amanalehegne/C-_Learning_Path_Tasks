[Flags]
public enum Category
{
    Personal = 1,
    Work = 2,
    Errand = 4,
    Avialable = Personal | Work | Errand
};
