namespace RelatorioFR.Core.Domain.Entities
{
    public  class BaseReport
    {
        public BaseReport()
        { 
        
            ReportID = Guid.NewGuid();
        }

        public Guid ReportID { get; set; }
        
    }
}
