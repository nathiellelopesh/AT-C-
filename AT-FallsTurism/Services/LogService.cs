namespace AT_FallsTurism.Services {
    public class LogService {

        private static readonly List<string> _memoryLogs = new List<string>();
        // Caminho do arquivo de log
        private static readonly string _logFilePath = "system_operations.log";

        public static void LogToConsole(string message) {
            Console.WriteLine($"[CONSOLE] {DateTime.Now}: {message}");
        }

        public static void LogToFile(string message) {
            try {
                var logDirectory = Path.GetDirectoryName(_logFilePath);
                if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory)) {
                    Directory.CreateDirectory(logDirectory);
                }

                File.AppendAllText(_logFilePath, $"[FILE] {DateTime.Now}: {message}{Environment.NewLine}");
                Console.WriteLine($"Log gravado em arquivo: {_logFilePath}");
            } catch (Exception ex) {
                Console.WriteLine($"Erro ao gravar log no arquivo: {ex.Message}");
            }
        }

        public static void LogToMemory(string message) {
            _memoryLogs.Add($"[MEMORY] {DateTime.Now}: {message}");
            Console.WriteLine($"Log adicionado à memória. Total de logs em memória: {_memoryLogs.Count}"); 
        }

        public static IReadOnlyList<string> GetMemoryLogs() {
            return _memoryLogs.AsReadOnly();
        }

        public static void ClearMemoryLogs() {
            _memoryLogs.Clear();
            Console.WriteLine("Logs em memória limpos.");
        }
    }
}
