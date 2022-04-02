using System.Collections.Generic;

namespace WebSite.Application.Services.Alerts.Queries.GetAlert
{
    public class ResultGetAlertListDto
    {
        public List<ResultGetAlertDto> ResultGetAlertDtos { get; }

        public int RowsCount { get; }

        public ResultGetAlertListDto(int rowsCount, List<ResultGetAlertDto> resultGetAlertDtos)
        {
            RowsCount = rowsCount;
            ResultGetAlertDtos = resultGetAlertDtos;
        }
    }
}
