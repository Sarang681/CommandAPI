using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;

        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }

        public bool SaveChanges() {
            return _context.SaveChanges() >= 0;
        }

        public void CreateCommand(Command command)
        {
            if (command == null) 
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.CommandItems.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null) 
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.CommandItems.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(cmd => cmd.Id == id);
        }

        public void UpdateCommand(Command command)
        {
            
        }
    }
}