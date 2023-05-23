namespace COMP003B.AssignmentFinal.Services
{
    public class MyTransientService
    {
        // private field
        private readonly Guid _uniqueId;
        // default constructor
        public MyTransientService()
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
