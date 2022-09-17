namespace AspnetNUnit.Mocking
{
    public interface IStatementGenerator
    {
        string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
    }

    public class StatementGenerator : IStatementGenerator
    {
        public string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate)
        {
            var report = new HousekeeperStatementReport(housekeeperOid, statementDate);

            if (!report.HasData)
                return string.Empty;

            HousekeeperStatementReport.CreateDocument();

            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                string.Format("Sandpiper Statement {0:yyyy-MM} {1}.pdf", statementDate, housekeeperName));

            HousekeeperStatementReport.ExportToPdf(filename);

            return filename;
        }

    }
}