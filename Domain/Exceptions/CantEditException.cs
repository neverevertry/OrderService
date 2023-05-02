namespace Domain.Exceptions
{
    public class CantEditException : Exception
    {
        public CantEditException(string editValue) : base(@$"Нельзя редактировать + {editValue}")
        {
        }
    }
}
