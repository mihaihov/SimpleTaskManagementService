namespace TaskManagementService {
    public class Task {
        public Guid Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public string Status {get; set;} = string.Empty;
        public Guid? UserId {get;set;} = null;
    }
}