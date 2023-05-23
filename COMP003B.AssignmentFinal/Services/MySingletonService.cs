namespace COMP003B.AssignmentFinal.Services
{
    public class MySingletonService
    {
        // private field
        private readonly Guid _uniqueId;
        // default constructor
        public MySingletonService()
        {
            _uniqueId = Guid.NewGuid();
        }
        // public method that returns the _uniqueId value
        public Guid GetUniqueId()
        {
            return _uniqueId;
        }
    }
}
